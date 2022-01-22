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
            if (checker.checkProcess() == false) Environment.Exit(-1);

            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            String login = loginBox.Text;
            String password = passwordBox.Text;

            Authorization checkLogin = new Authorization();

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
                MessageBox.Show("Error entry! Try again");
            }
        }
    }
}
