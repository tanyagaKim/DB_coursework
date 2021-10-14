using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Staff_database
{
    public partial class MainForm : Form
    {
        SqlConnection connection = null;

        public MainForm(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.connection.Open();
            }
            catch
            {
                MessageBox.Show("Сonnectoin open error");
                return;
            }

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT * FROM [personnel_accounting].[dbo].[Fired_card]", connection);

            adapter.SelectCommand = command;

            try
            {
                adapter.Fill(new DataTable());
            }
            catch
            {
                MessageBox.Show("Error access");
                connection.Close();
                return;
            }

            connection.Close();

            PersonalCardForm psC = new PersonalCardForm(connection);
            psC.TopLevel = false;
            content.Controls.Clear();
            content.Controls.Add(psC);
            psC.Show();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            try
            {
                this.connection.Open();
            }
            catch
            {
                MessageBox.Show("Сonnectoin open error");
                return;
            }

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT * FROM [personnel_accounting].[dbo].[users]", connection);

            adapter.SelectCommand = command;

            try
            {
                adapter.Fill(new DataTable());
            }
            catch
            {
                MessageBox.Show("Error access");
                connection.Close();
                return;
            }

            connection.Close();

            SettingsForm settings = new SettingsForm(connection);
            settings.TopLevel = false;
            content.Controls.Clear();
            content.Controls.Add(settings);
            settings.Show();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void kryptonButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.connection.Open();
            }
            catch
            {
                MessageBox.Show("Сonnectoin open error");
                return;
            }

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT * FROM [personnel_accounting].[dbo].[Fired_card]", connection);

            adapter.SelectCommand = command;

            try
            {
                adapter.Fill(new DataTable());
            }
            catch
            {
                MessageBox.Show("Error access");
                connection.Close();
                return;
            }

            connection.Close();

            FiredsForm reports = new FiredsForm(connection);
            reports.TopLevel = false;
            content.Controls.Clear();
            content.Controls.Add(reports);
            reports.Show();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            try
            {
                this.connection.Open();
            }
            catch
            {
                MessageBox.Show("Сonnectoin open error");
                return;
            }

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT * FROM [personnel_accounting].[dbo].[Accreditation]", connection);

            adapter.SelectCommand = command;

            try
            {
                adapter.Fill(new DataTable());
            }
            catch
            {
                MessageBox.Show("Error access");
                connection.Close();
                return;
            }

            connection.Close();

            AccreditationForm reports = new AccreditationForm(connection);
            reports.TopLevel = false;
            content.Controls.Clear();
            content.Controls.Add(reports);
            reports.Show();
        }
    }
}
