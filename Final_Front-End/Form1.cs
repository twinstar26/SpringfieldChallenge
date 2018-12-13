using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace SpringfieldChallenge
{
    public partial class Form1 : Form
    {
        string[] filepath;
        string output_path;
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            this.button1.Hide();
            this.label3.Show();
            this.dataGridView1.Show();
            this.button2.Show();

            //this.openFileDialog1.ShowDialog();

        }
        private void button2_Click_2(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
            
            int length = 0;
            filepath = openFileDialog1.FileNames;
            length = filepath.Length;
         

            dataGridView1.Columns.Add("col1", "FILEPATH");
            DataTable table = new DataTable("FILETABLE");
            table.Columns.Add("FILEPATH", typeof(string));
            for (int i = 0; i < length; i++)
            {
                table.Rows.Add(filepath[i]);
            }
            for (int i = 0; i < table.Rows.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, i].Value = table.Rows[i]["FILEPATH"];
            }

        }

        private void button4_Click_4(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
            output_path = folderBrowserDialog1.SelectedPath;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.Columns.Add("col1", "FILEPATH");
            DataTable table = new DataTable("FILETABLE");
            table.Columns.Add("FILEPATH", typeof(string));
            table.Rows.Add(output_path);
            dataGridView2.Rows.Add();
            dataGridView2[0, 0].Value = table.Rows[0]["FILEPATH"];
       
        }
        private void label1_Click(object sender, EventArgs e)
        {
           //
        }
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void button5_Click_5(object sender, EventArgs e)
        {
            this.button6.Show();
        }

        private void button6_Click_6(object sender, EventArgs e)
        {
            this.button1.Show();
            this.button2.Show();
            this.button3.Show();
            this.button4.Show();
            this.dataGridView1.Show();
            this.dataGridView2.Show();
            this.label1.Hide();
            this.label3.Show();
            this.label4.Show();
            this.comboBox1.Hide();
            this.button5.Hide();
            this.button6.Hide();
        }
        private void button3_Click_3(object sender, EventArgs e)
        {
            //CONNECT TO THE BACKEND
            //        string[] filepath;
            //string output_path;
        }
    }

   
}
