using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staff_database
{
    public partial class FiredsForm : Form
    {
        SqlConnection connection = null;

        public FiredsForm(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;

            this.connection.Open();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT * FROM [personnel_accounting].[dbo].[Fired_card]", connection);

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

            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Empty personal_card table");
                connection.Close();
                return;
            }
            firedTable.DataSource = table;
            firedTable.Update();

            this.connection.Close();
        }

        private void AccoutingLabel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void firedTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void createCardBox_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonLabel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void birthdayText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
