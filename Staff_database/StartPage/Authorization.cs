using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Xml;

namespace Staff_database
{
    public class Authorization
    {
        private String getConnectionString()
        {
            String connectionString = string.Empty;

            String server = string.Empty;
            String name = string.Empty;
            String pass = string.Empty;

            XmlTextReader reader = null;

            /*try
            {*/
                reader = new XmlTextReader(@"C:/Users/Татьяна/Desktop/Институт/бд курсач/Staff_database/Staff_database/src/config.xml");

                reader.MoveToContent();
                server = reader.GetAttribute("server");
                name = reader.GetAttribute("name");
                pass = reader.GetAttribute("password");

                connectionString = "User Id=" + name + ";Password=" + pass + ";Server=" + server;
            /*}

            catch
            {
                MessageBox.Show("Config file open error");
            }

            finally
            {*/
                if (reader != null)
                    reader.Close();
            //}

            return connectionString;
        }

        public String getSalt(SqlConnection connection, String login)
        {
            String salt = string.Empty;

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT [Salt] FROM [personnel_accounting].[dbo].[users] WHERE login = @login", connection);
            command.Parameters.Add("@login", SqlDbType.NVarChar).Value = login;

            adapter.SelectCommand = command;
            command.Dispose();

            /*try
            {*/
                adapter.Fill(table);
            /*}
            catch
            {
                MessageBox.Show("Error access to users_table");
            }
            */
            if (table.Rows.Count < 1)
            {
                MessageBox.Show("Error entry! Try again");
            }
            else
            {
                salt = table.Rows[0]["Salt"].ToString();
            }

            return salt;
        }

        private String getHashed(String str_salt, String password)
        {
            byte[] salt = Convert.FromBase64String(str_salt);

            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

        private bool checkHash(SqlConnection connection, String login, String hashed)
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT * FROM [personnel_accounting].[dbo].[users] WHERE login = @login AND hash = @hash", connection);
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
            }

            return table.Rows.Count > 0;
        }

        private bool checkPerson(SqlConnection connection, String login, String password)
        {
            String str_salt = getSalt(connection, login);

            String hashed = getHashed(str_salt, password);

            return checkHash(connection, login, hashed);
        }

        private bool checkConnection(String connectionString, String login, String password)
        {
            bool flag = false;

            SqlConnection connection =  new SqlConnection(connectionString);

            /*try
            {*/
                connection.Open();
            /*}
            catch
            {
                MessageBox.Show("Сonnectoin open error");
            }*/
            
            flag = checkPerson(connection, login, password);
            connection.Close();
            connection.Dispose();

            return flag;

        }

        public bool loginDB(String login, String password)
        {
            bool flag = false;

            String connectionString = getConnectionString();

            if (connectionString != string.Empty) flag = checkConnection(connectionString, login, password);

            return flag;
        }

        public String getServer()
        {
            String server = string.Empty;

            XmlTextReader reader = null;
            
            /*try
            {*/
                reader = new XmlTextReader(@"C:/Users/Татьяна/Desktop/Институт/бд курсач/Staff_database/Staff_database/src/config.xml");
                
                reader.MoveToContent();
                server = reader.GetAttribute("server");
            /*}

            catch
            {
                MessageBox.Show("Config file open error");
            }

            finally
            {*/
                if (reader != null)
                    reader.Close();
            //}
            
            return server;
        }
    }
}
