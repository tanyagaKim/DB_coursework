using System;
using System.IO;
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
    public partial class PersonalCardForm : Form
    {
        SqlConnection connection = null;

        private void set_table()
        {
            connection.Open();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT pc.id, pc.name, education, p.name as post FROM [personnel_accounting].[dbo].[Personal_card] AS pc join" +
                " [personnel_accounting].[dbo].[Posts] AS p on pc.post_id = p.id order by pc.id desc", connection);

            adapter.SelectCommand = command;


            try
            {
                adapter.Fill(table);
            }
            catch
            {
                MessageBox.Show("Error access to tables");
                connection.Close();
                return;
            }

            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Empty personal_card table");
                connection.Close();
                return;
            }
            personalCardTable.DataSource = table;
            personalCardTable.Update();
            connection.Close();
        }

        public PersonalCardForm(SqlConnection connection)
        {
            InitializeComponent();

            this.connection = connection;

            set_table();
        }

        private void personalCardsButton_Click(object sender, EventArgs e)
        {
            String nam = nameText.Text;
            String birth = birthdayText.Text;
            String spec = specText.Text;
            String educ = educBox.Text;
            String pas_ser = passerText.Text;
            String pas_num = pasnumberText.Text;
            String post_id = postidText.Text;
            
            if (nam is "" || birth is "" || pas_ser is "" || pas_num is "" || post_id is "" || educ is "")
            {
                MessageBox.Show("Data include empty string!");
                return;
            }

            connection.Open();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT MAX(id)as m FROM [personnel_accounting].[dbo].[Personal_card] ", connection);

            adapter.SelectCommand = command;

            try
            {
                adapter.Fill(table);
            }
            catch
            {
                MessageBox.Show("Error access to tables");
                connection.Close();
                return;
            }

            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Empty personal_card table");
                connection.Close();
                return;
            }

            int id = Int32.Parse(table.Rows[0]["m"].ToString())+ 1;

            command.Dispose();

            command = new SqlCommand("INSERT INTO [personnel_accounting].[dbo].[Personal_card]" +
                "(id, name, birthday, speciality, education, pas_series, pas_number, post_id) VALUES ( '" + id + "', '" +
                nam + "','" + birth +"', '" + spec +"', '" + educ + "', " + pas_ser + ", " + pas_num + ", " + post_id + ")", connection);
            
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Error insert into table!");
                return;
            }
            
            MessageBox.Show("Success added");

            connection.Close();

            set_table();
        }

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PersonalCardForm_Load(object sender, EventArgs e)
        {

        }

        private void kryptonPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AccoutingLabel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonLabel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void try_del_id(String id)
        {
            if (id is "") return;

            connection.Open();

            SqlCommand command = new SqlCommand("use personnel_accounting; EXEC [dbo].Delete_pc @id", connection);
            command.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;

            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Error delete from fired_card table!");
                connection.Close();
                return;
            }

            connection.Close();

            set_table();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            String fio = fioText.Text;
            String id = idText.Text;

            if (id is "" && fio != "")
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT id FROM [personnel_accounting].[dbo].[Personal_card] where name ='" + fio + "'", connection);


                DataTable table = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter();

                adapter.SelectCommand = command;

                try
                {
                    adapter.Fill(table);
                }
                catch
                {
                    MessageBox.Show("Error access to tables");
                    connection.Close();
                    return;
                }

                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("No such person");
                    connection.Close();
                    return;
                }

                id = table.Rows[0]["id"].ToString();

                connection.Close();
            }

            try_del_id(id);

            fioText.Text = "";
            idText.Text = "";
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            String id = idBox.Text;

            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM [personnel_accounting].[dbo].[Personal_card] where id ='" + id + "'", connection);

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.SelectCommand = command;

            try
            {
                adapter.Fill(table);
            }
            catch
            {
                MessageBox.Show("Error access to tables");
                connection.Close();
                return;
            }

            if (table.Rows.Count == 0)
            {
                MessageBox.Show("No such person");
                connection.Close();
                return;
            }

            nameBox.Text = table.Rows[0]["name"].ToString();
            birthdayBox.Text = table.Rows[0]["birthday"].ToString();
            educationalBox.Text = table.Rows[0]["education"].ToString();
            specBox.Text = table.Rows[0]["speciality"].ToString();
            passerBox.Text = table.Rows[0]["pas_number"].ToString();
            pasnumBox.Text = table.Rows[0]["pas_series"].ToString();
            postBox.Text = table.Rows[0]["post_id"].ToString();

            connection.Close();
        }

        private void kryptonTextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            String id = idBox.Text;
            String name = nameBox.Text;
            String bith = birthdayBox.Text;
            String educ = educationalBox.Text;
            String spec = specBox.Text;
            String passer = passerBox.Text;
            String pasnum= pasnumBox.Text;
            String post = postBox.Text;

            connection.Open();

            SqlCommand command = new SqlCommand("UPDATE () [personnel_accounting].[dbo].[Personal_card] where id ='" + id + "'", connection);
            //command.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;

            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Error update personal_card table!");
                connection.Close();
                return;
            }

            connection.Close();

            set_table();
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            if (filePathText.Text is "Выберите файл")
            {
                MessageBox.Show("Choose the file!");
                return;
            }

            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM [personnel_accounting].[dbo].[Fired_card]; " +
                "DELETE FROM [personnel_accounting].[dbo].[Accreditation];" +
                "DELETE FROM [personnel_accounting].[dbo].[Personal_card];", connection);
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Error delete fired_card table!");
                connection.Close();
                return;
            }
            command.Dispose();           

            command = new SqlCommand("USE personnel_accounting; INSERT INTO [dbo].[Personal_card] (Id, Create_data, Name, Birthday, Education, Institute, " +
                "Speciality, Diploma_number, Pas_series, Pas_number, Post_id) SELECT * FROM OPENDATASOURCE('Microsoft.ACE.OLEDB.12.0'," +
                "'Data Source=" + filePathText.Text + ";Extended Properties=Excel 12.0;')...[Лист1$]; ", connection);
                       
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Error update personal_card table!");
                connection.Close();
                return;
            }
            
            connection.Close();

            set_table();
        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.xls)|*.xlsx|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }

            //MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
            filePathText.Text = filePath;
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            if (filePathText.Text is "Выберите файл")
            {
                MessageBox.Show("Choose the file!");
                return;
            }

            connection.Open();

            SqlCommand command = new SqlCommand("insert into OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'Excel 12.0;Database=" + 
                filePathText.Text + ";','SELECT * FROM [Лист1$]') select * from [personnel_accounting].[dbo].[Personal_card];", connection);
                        
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Import finished");
                connection.Close();
                return;
            }

            MessageBox.Show("Import finished success");

            connection.Close();
        }
    }
}
