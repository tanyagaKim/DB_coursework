using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using OfficeOpenXml.Core.ExcelPackage;
//using OfficeOpenXml.Core.ExcelPackage;
using Excel = Microsoft.Office.Interop.Excel;


namespace Staff_database
{
    public partial class AccreditationForm : Form
    {
        SqlConnection connection = null;

        public AccreditationForm(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;

            this.connection.Open();

            System.Data.DataTable table = new System.Data.DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT * FROM [personnel_accounting].[dbo].[Accreditation]", connection);

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
            accreditationTable.DataSource = table;
            accreditationTable.Update();         

            this.connection.Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            /*********/
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
            /*********/
        }

        private void filePathText_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {

            //Excel.Application app = new Excel.Application();
            //Workbook book = app.Workbooks.Open(@"C:\Users\Татьяна\Desktop\бд курсач\Template_PC.xlsx");

            //_Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            //Range xlRange = xlWorksheet.UsedRange;
            //Workbook mybook = new Workbook();
            //Workbook mybook = new Workbook();//xlApp.Workbooks.Open(@"C:\Users\Татьяна\Desktop\бд курсач\Buff.xlsx");

            //_Worksheet xlWorksheet = book.Worksheets[1];
            //book.Worksheets[1].Copy(xlWorksheet);

            //mybook.Close();
            //book.Close();
            try
            {
                this.connection.Open();
            }
            catch
            {
                MessageBox.Show("Сonnectoin open error");
                return;
            }

            SqlCommand command = new SqlCommand("insert into OPENROWSET('Microsoft.ACE.OLEDB.12.0','Excel 12.0;Database=C:\\Users\\Татьяна\\Desktop\\бд курсач\\Template_PC.xlsx;'," +
                "'SELECT * FROM [Лист1$]') select * from Personal_card", connection);
            //command.ExecuteNonQuery();
            
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Export is done!");
            }
            
            MessageBox.Show("End of added!");

            command.Dispose();
            this.connection.Close();
        }

        private void accreditationPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonLabel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton10_Click(object sender, EventArgs e)
        {
            countBox.Text = "1900";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
