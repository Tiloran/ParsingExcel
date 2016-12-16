using ParsingExel.Parsing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
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
            if(OpenExcel.ShowDialog() == DialogResult.OK)
            {
                textBox_Path.Text = OpenExcel.FileName;
            }

        }

        private void Load_button_Click(object sender, EventArgs e)
        {            
            string PathConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBox_Path.Text + ";Extended Properties = \"Excel 12.0 Xml;HDR=YES\"; ";
            OleDbConnection conn = new OleDbConnection(PathConn);
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter("Select * from [" + textBox_sheet.Text + "$]", conn);
            DataTable dt = new DataTable();
            myDataAdapter.Fill(dt);
            ParsingTV.AddtoDBTV(dt);
            dataGridView1.DataSource = dt;
            textBox_result.Text = "OK";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse("agds", out n);
            textBox_result.Text = n.ToString();
        }
    }
}
