using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Staff_database
{
    public partial class SettingsForm : Form
    {
        SqlConnection connection = null;

        public SettingsForm(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        private void personalCardsButton_Click(object sender, EventArgs e)
        {
            String login = loginText.Text;
            String password = passwordText.Text;
            String role = roleText.Text;

            switch (roleText.Text)
            {
                case "Администратор": role = "adm"; break;
                case "Бухгалтер": role = "acc"; break;
                case "Кадровик": role = "hr"; break;
            }

            // generate a 128-bit salt using a cryptographically strong random sequence of nonzero values

            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }

            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            try
            {
                this.connection.Open();
            }
            catch
            {
                MessageBox.Show("Сonnectoin open error");
                return;
            }

            SqlCommand command = new SqlCommand("INSERT INTO [personnel_accounting].[dbo].[users](login, salt, hash) VALUES(@login, @salt, @hash)", this.connection);
            command.Parameters.Add("@login", SqlDbType.NVarChar).Value = login;
            command.Parameters.Add("@salt", SqlDbType.NVarChar).Value = Convert.ToBase64String(salt);
            command.Parameters.Add("@hash", SqlDbType.NVarChar).Value = hashed.ToString();
                        
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("User already exsists in users!");
                //connection.Close();
                //return;
            }

            command.Dispose();
            command = new SqlCommand("USE personnel_accounting; CREATE LOGIN [" + login +"] WITH PASSWORD = '" + password + "'", connection);
            //command.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
            //command.Parameters.Add("@password", SqlDbType.VarChar).Value = password;

            try {
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Inter point already exsists!");
                //connection.Close();
                //return;
            }

            command.Dispose();
            command = new SqlCommand("USE [personnel_accounting]; CREATE USER [" + login + "] FOR LOGIN [" + login + "]", connection);
            //command.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
           
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("User already exsists in DB!");
                //connection.Close();
                //return;
            }

            command.Dispose();
            command = new SqlCommand("ALTER ROLE [" + role + "] ADD MEMBER [" + login + "]", connection);
            //command.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
            
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("User already in group!");
                //connection.Close();
                //return;
            }

            if (role == "adm")
            {
                command.Dispose();
                command = new SqlCommand("USE master; GRANT ALTER ANY LOGIN TO [" + login + "]", connection);
                //command.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
                
                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Can't grand options to admin!");
                    //connection.Close();
                    //return;
                }
            }

            MessageBox.Show("User succsesfully added!");

            command.Dispose();
            this.connection.Close();
        }

        private void deleteUser_Click(object sender, EventArgs e)
        {
            String login = loginBox.Text;

            String role = roleBox.Text;

            switch (roleBox.Text)
            {
                case "Администратор": role = "adm"; break;
                case "Бухгалтер": role = "acc"; break;
                case "Кадровик": role = "hr"; break;
            }
            
            try
            {
                this.connection.Open();
            }
            catch
            {
                MessageBox.Show("Сonnectoin open error");
                return;
            }

            SqlCommand command = new SqlCommand("USE [personnel_accounting]; ALTER ROLE [" + role + "] DROP MEMBER [" + login + "]", connection);
            //command.Parameters.Add("@login", SqlDbType.NVarChar).Value = login;

            int n = 0;
            try
            {
                n = command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("User already delete from group!");
                connection.Close();
                return;
            }
            
            if (n == 0)
            {
                MessageBox.Show("Error ALTER ROLER");
                connection.Close();
                return;
            }

            command.Dispose();
            command = new SqlCommand("DROP USER IF EXISTS ["+ login + "]", connection);
            //command.Parameters.Add("@login", SqlDbType.NVarChar).Value = login;

            try
            {
                n = command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("User already deleted!");
                connection.Close();
                return;
            }

            if (n == 0)
            {
                MessageBox.Show("Error DROP USER");
                connection.Close();
                return;
            }

            command.Dispose();
            command = new SqlCommand("DROP LOGIN [" + login + "]", connection);
            //command.Parameters.Add("@login", SqlDbType.NVarChar).Value = login;

            try
            {
                n = command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Login already deleted!");
                connection.Close();
                return;
            }

            if (n == 0)
            {
                MessageBox.Show("Error DROP LOGIN");
                connection.Close();
                return;
            }

            command.Dispose();
            command = new SqlCommand("DELETE FROM [personnel_accounting].[dbo].[users] WHERE login = @login", connection);
            command.Parameters.Add("@login", SqlDbType.NVarChar).Value = login;

            try
            {
                n = command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Login already deleted!");
                connection.Close();
                return;
            }

            if (n == 0)
            {
                MessageBox.Show("Error DROP LOGIN");
                connection.Close();
                return;
            }

            MessageBox.Show("User succsesfully deleted!");

            command.Dispose();
            this.connection.Close();
        }
    }
}
