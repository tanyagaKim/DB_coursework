using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Staff_database
{
    public partial class LoginForm : Form
    {
        
        public LoginForm()
        {
            LicenceChecker checker = new LicenceChecker();
            try
            {
                if (checker.checkProcess() == false)
                {
                    MessageBox.Show("Wrong licence");
                    Environment.Exit(-1);
                }

                InitializeComponent();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(-1);
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            String login = loginBox.Text;
            String password = passwordBox.Text;

            Authorization checkLogin = new Authorization();

            try
            {
                if (checkLogin.loginDB(login, password) == true)
                {
                    this.Hide();

                    string server = checkLogin.getServer();

                    String newConnectionString = "user Id=" + login + ";password=" + password + ";server=" + server;

                    SqlConnection connection = new SqlConnection(newConnectionString);
                    MainForm mainForm = new MainForm(connection);
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Wrong login or password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
