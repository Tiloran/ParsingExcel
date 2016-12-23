
using OfficeOpenXml;
using ParsingExel.Enum;
using ParsingExel.Parsing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ParsingExel
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }


        private void Choose_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenExcel = new OpenFileDialog();
            if (OpenExcel.ShowDialog() == DialogResult.OK)
            {
                textBox_Path.Text = OpenExcel.FileName;
            }

        }

        private void Load_button_Click(object sender, EventArgs e)
        {
            string PathConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBox_Path.Text + ";Extended Properties = \"Excel 12.0 Xml;HDR=YES\"; ";
            OleDbConnection conn = new OleDbConnection(PathConn);
            DataTable dt = new DataTable();
            conn.Open();
            dt = conn.GetSchema("Tables");
            
            foreach (var dr in dt.Rows)
            {
                if (!(((DataRow)dr)["TABLE_NAME"].ToString().Contains("Print_Area")))
                {
                    TableVariantsBox.Items.Add(((DataRow)dr)["TABLE_NAME"].ToString());
                }
            }


            conn.Close();
            //Parsing5Doors.AddtoDB5Doors(dt);
            //textBox_result.Text = "OK";

            //string sSheetName = null;
            //string sConnection = null;
            //DataTable dtTablesList = default(DataTable);
            //OleDbCommand oleExcelCommand = default(OleDbCommand);
            //OleDbDataReader oleExcelReader = default(OleDbDataReader);
            //OleDbConnection oleExcelConnection = default(OleDbConnection);

            //var executionPath = Path.GetDirectoryName(Application.ExecutablePath);
            //sConnection = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={executionPath}\\her.xlsx;Extended Properties = \"Excel 12.0 Xml;HDR=YES\""; ;

            //oleExcelConnection = new OleDbConnection(sConnection);
            //oleExcelConnection.Open();

            //dtTablesList = oleExcelConnection.GetSchema("Tables");

            //foreach (var dr in dtTablesList.Rows)
            //{
            //    sSheetName = ((DataRow)dr)["TABLE_NAME"].ToString();
            //    OleDbDataAdapter myDataAdapter = new OleDbDataAdapter($"Select * from [{ sSheetName}]", oleExcelConnection);
            //    DataTable dt = new DataTable();
            //    myDataAdapter.Fill(dt);
            //    ParsingHelper.ProceedMethodForSheet(sSheetName, dt);
            //}


            //dtTablesList.Clear();
            //dtTablesList.Dispose();
            //oleExcelConnection.Close();






        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string PathConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBox_Path.Text + ";Extended Properties = \"Excel 12.0 Xml;HDR=YES\"; ";
            OleDbConnection conn = new OleDbConnection(PathConn);
            DataTable dt = new DataTable();
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(@"Select * from [" + TableVariantsBox.SelectedItem + "]", conn);
            dt = new DataTable();
            myDataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Divide_button_Click(object sender, EventArgs e)
        {              
            DataTable dt = ImportToDataTable(textBox_Path.Text, TableVariantsBox.SelectedItem.ToString() );
            textBox_result.Text = ParsingCorner.AddtoDBCorner(dt);
            dataGridView1.DataSource = dt;
        }

        public static DataTable ImportToDataTable(string FilePath, string SheetName)
        {
            DataTable dt = new DataTable();
            FileInfo fi = new FileInfo(FilePath);

            // Check if the file exists
            if (!fi.Exists)
                throw new Exception("File " + FilePath + " Does Not Exists");

            using (ExcelPackage xlPackage = new ExcelPackage(fi))
            {
                // get the first worksheet in the workbook
                ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets[SheetName];

                // Fetch the WorkSheet size
                ExcelCellAddress startCell = worksheet.Dimension.Start;
                ExcelCellAddress endCell = worksheet.Dimension.End;

                // create all the needed DataColumn
                for (int col = startCell.Column; col <= endCell.Column; col++)
                    dt.Columns.Add(col.ToString());

                // place all the data into DataTable
                for (int row = startCell.Row; row <= endCell.Row; row++)
                {
                    DataRow dr = dt.NewRow();
                    int x = 0;
                    for (int col = startCell.Column; col <= endCell.Column; col++)
                    {
                        dr[x++] = worksheet.Cells[row, col].Value;
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }        
    }
}

