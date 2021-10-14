using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Xml;

namespace Staff_database
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            String login = loginBox.Text; 
            String password = passwordBox.Text;

            String server = "";
            String name = "";
            String pass = "";

            XmlTextReader reader = null;

            try
            {
                reader = new XmlTextReader("config.xml");

                reader.MoveToContent();
                server = reader.GetAttribute("server");
                name  = reader.GetAttribute("name");
                pass = reader.GetAttribute("password");
            }

            catch
            {
                MessageBox.Show("XML open error");
                return;
            }

            finally
            {
                if (reader != null)
                    reader.Close();
            }

            String connectionString = "User Id="+ name + ";Password="+ pass +";Server="+ server;
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
            }
            catch
            {
                MessageBox.Show("Сonnectoin open error");
                return;
            }

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT [Salt] FROM [personnel_accounting].[dbo].[users] WHERE login = @login", connection);
            command.Parameters.Add("@login", SqlDbType.NVarChar).Value = login;

            adapter.SelectCommand = command;
            command.Dispose();

            try
            {
                adapter.Fill(table);
            }
            catch
            {
                MessageBox.Show("Error access to users_table");
                connection.Close();
                return;
            }

            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Error entry! Try again");
                connection.Close();
                return;
            }

            String str_salt = table.Rows[0]["Salt"].ToString();

            table.Clear();

            byte[] salt = Convert.FromBase64String(str_salt);

            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            command = new SqlCommand("SELECT * FROM [personnel_accounting].[dbo].[users] WHERE login = @login AND hash = @hash", connection); 
            command.Parameters.Add("@login", SqlDbType.NVarChar).Value = login;
            command.Parameters.Add("@hash", SqlDbType.NVarChar).Value = hashed;

            adapter.SelectCommand = command;

            try
            {
                adapter.Fill(table);
            }
            catch
            {
                MessageBox.Show("Error access to users_table");
                connection.Close();
                return;
            }

            connection.Close();
            connection.Dispose();

            if (table.Rows.Count > 0)
            {
                this.Hide();

                String newConnectionString =  "user Id=" + login + ";password="+ password + ";server=" + server;
                
                connection = new SqlConnection(newConnectionString);
                MainForm mainForm = new MainForm(connection);
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Error entry! Try again");
            }
        }
    }
}
