using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Staff_database
{
    public partial class MainForm : Form
    {
        private SqlConnection connection = null;
        private SelectTable selector = null;

        public MainForm(SqlConnection connection)
        {
            try
            {
                this.connection = connection;
                this.connection.Open();
            }
            catch
            {
                MessageBox.Show("Сonnectoin open error");
                return;
            }
            this.connection.Close();
            selector = new SelectTable();

            InitializeComponent();
        }

        public void checkAccess(string commandString)
        {
            try
            {
                SqlDataAdapter adapter = selector.selectCommand(commandString, connection);
                adapter.Fill(new DataTable());
            }
            catch
            {
                throw new Exception("Error access");
            }
        }
        
        private void personalCardsButton_Click(object sender, EventArgs e)
        {
            try
            {
                checkAccess("SELECT * FROM [personnel_accounting].[dbo].[Personal_card]");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
                return;
            }

            PersonalCardForm psC = new PersonalCardForm(connection);
            psC.TopLevel = false;
            content.Controls.Clear();
            content.Controls.Add(psC);
            psC.Show();
        }
        
        private void settingsButton_Click(object sender, EventArgs e)
        {
            try
            {
                checkAccess("SELECT * FROM [personnel_accounting].[dbo].[users]");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
                return;
            }

            SettingsForm settings = new SettingsForm(connection);
            settings.TopLevel = false;
            content.Controls.Clear();
            content.Controls.Add(settings);
            settings.Show();
        }
        
        private void firedFormButton_Click(object sender, EventArgs e)
        {
            try
            {
                checkAccess("SELECT * FROM [personnel_accounting].[dbo].[Fired_card]");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
                return;
            }

            FiredsForm reports = new FiredsForm(connection);
            reports.TopLevel = false;
            content.Controls.Clear();
            content.Controls.Add(reports);
            reports.Show();
        }
        
        private void accreditationButton_Click(object sender, EventArgs e)
        {
            try
            {
                checkAccess("SELECT * FROM [personnel_accounting].[dbo].[Accreditation]");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
                return;
            }
            
            AccreditationForm reports = new AccreditationForm(connection);
            reports.TopLevel = false;
            content.Controls.Clear();
            content.Controls.Add(reports);
            reports.Show();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
