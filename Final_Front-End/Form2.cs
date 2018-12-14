using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace SpringfieldChallenge
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string[] filepath;
        string[] rules = new string [1000];
        string[] temp = new string[1000];
        string sets = "Sets";
        string tags;
        string setname;
        string selected_set;

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem!=null)
            { 
                selected_set = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                int index1 = selected_set.IndexOf(@"=");
                int index2 = selected_set.IndexOf(@",");
                int len = index2 - index1 - 2;
                selected_set = selected_set.Substring(index1 + 2, len);
            }
            if (!string.IsNullOrEmpty(selected_set))
                this.button3.Show();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            this.comboBox1.Hide();
            this.button1.Hide();
            this.button2.Hide();
            this.button3.Hide();
            this.label1.Show();
            this.label2.Show();
            this.richTextBox1.Show();
            this.richTextBox2.Show();
            this.button4.Show();
        }
        private void button4_Click_4(object sender, EventArgs e)
        {
            tags = this.richTextBox1.Text;
            setname = this.richTextBox2.Text;
        
            if(!(string.IsNullOrEmpty(tags)&& string.IsNullOrEmpty(tags)))
            {
                System.IO.File.WriteAllText(@setname,tags);
                System.IO.File.AppendAllText(sets, setname + "\n");
                this.button5.Show();

            } 
            
        }
        private void button3_Click_3(object sender, EventArgs e)
        {
            this.comboBox1.Hide();
            this.button1.Hide();
            this.button2.Hide();
            this.label5.Hide();
            //this.label6.Show();
            this.dataGridView1.Show();
            this.label3.Show();
            this.button6.Show();
            this.checkedListBox1.Show();
            string[] tags = File.ReadAllLines(@selected_set);
            checkedListBox1.DisplayMember = "Text";
            checkedListBox1.ValueMember = "Value";
            for (int i = 0; i < tags.Length; i++)
            {
                checkedListBox1.Items.Insert(i, new { Text = tags[i], Value = tags[i] });
            }
            this.button3.Hide();
            this.button8.Show();
        }
        private void button6_Click_6(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
            int length = 0;
            filepath = openFileDialog1.FileNames;
            dataGridView1.Columns.Add("col1", "FILEPATH");
            DataTable table = new DataTable("FILETABLE");
            table.Columns.Add("FILEPATH", typeof(string));
            table.Rows.Add(filepath[0]);
            dataGridView1.Rows.Add();
            dataGridView1[0, 0].Value = table.Rows[0]["FILEPATH"];
        }
        private void button5_Click_5(object sender, EventArgs e)
        {
            this.comboBox1.Show();
            this.button1.Show();
            this.button2.Show();
            this.button3.Hide();
            this.label1.Hide();
            this.label2.Hide();
            this.richTextBox1.Hide();
            this.richTextBox2.Hide();
            this.button4.Hide();
            this.button5.Hide();
            set2(setname);
            
        }

        private void button7_Click_7(object sender, EventArgs e)
        {

        }
        private void button8_Click_8(object sender, EventArgs e)
        {
            for (int x = 0; x < checkedListBox1.CheckedItems.Count; x++)
            {
                rules[x] = checkedListBox1.CheckedItems[x].ToString();
                Debug.WriteLine(checkedListBox1.CheckedItems[x].ToString());
            }

            if(!string.IsNullOrEmpty(rules[0]))
            {
                

                for (int i = 0; i< checkedListBox1.CheckedItems.Count; i++)
                {
                    int index1 = rules[i].IndexOf(@"=");
                    int index2 = rules[i].IndexOf(@",");
                    int len = index2 - index1 - 2; 
                    temp[i] = rules[i].Substring(index1 + 2, len);
                    System.IO.File.AppendAllText("CONFIG_" + selected_set , temp[i]+"\n");
                }
                
            }
            else
            {
                MessageBox.Show("PLEASE SELECT AT LEAST ONE RULE");
                
            }
            this.checkedListBox1.Hide();
            this.button6.Hide();
            this.label3.Hide();
            this.button8.Hide();
            this.dataGridView1.Hide();
            this.dataGridView2.Show();
            dataGridView2.Columns.Add("col1", "TAGS");
            dataGridView2.Columns.Add("col2", "START CHARACTER");
            dataGridView2.Columns.Add("col1", "END CHARACTER");
            dataGridView2.Columns.Add("col1", "OPERATION");
            DataTable table1 = new DataTable("FILETABLE");
            table1.Columns.Add("TAGS", typeof(string));
            table1.Columns.Add("START CHARACTER", typeof(string));
            table1.Columns.Add("END CHARACTER", typeof(string));
            table1.Columns.Add("OPERATION", typeof(string));
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                Debug.WriteLine(temp[i]);
                table1.Rows.Add(temp[i]);
                dataGridView2.Rows.Add();
                dataGridView2[0, i].Value = table1.Rows[i]["TAGS"];
            }
            this.label6.Show();
            this.button9.Show();
        }

        private void button9_Click_9(object sender, EventArgs e)
        {
            for (int rows = 0; rows < dataGridView2.Rows.Count; rows++)
            {
                
                try
                {
                    string.IsNullOrEmpty(dataGridView2.Rows[rows].Cells[3].Value.ToString());
                }
                catch(System.NullReferenceException p1)
                {
                    MessageBox.Show("PLEASE FILL ALL THE ENTRIES IN COLOUMN \"OPERATION\"");
                }
            }
            string finalcommand = "python3 BatchOCREngine.py " + filepath[0] + " " + selected_set + " ";
            for (int rows = 0; rows < dataGridView2.Rows.Count; rows++)
            {
                string value = dataGridView2.Rows[rows].Cells[0].Value.ToString();
                string avalue = value.Replace(" ", "_");
                string bvalue = avalue + "[\\'";


                //string value = dataGridView2.Rows[rows].Cells[col].Value.ToString();
                string evalue;
                string cvalue;
                string hvalue;
                try
                {
                    cvalue = dataGridView2.Rows[rows].Cells[1].Value.ToString();
                }
                catch (System.NullReferenceException p)
                {
                    cvalue = "\\";
                }
                
                string dvalue = "',\\'";
                try
                {
                    evalue = dataGridView2.Rows[rows].Cells[2].Value.ToString();
                }
                catch(System.NullReferenceException f)
                {
                    evalue = "\\";
                }
                
                string gvalue = bvalue + cvalue + dvalue + evalue + "\\']";
                try
                {
                    hvalue = dataGridView2.Rows[rows].Cells[3].Value.ToString();
                }
                catch (System.NullReferenceException p1)
                {
                    MessageBox.Show("PLEASE FILL ALL THE ENTRIES IN COLOUMN \"OPERATION\"");
                    hvalue = "f";
                }
               
                string fvalue = gvalue + hvalue;

                
                finalcommand += fvalue + " ";
            }
            Debug.WriteLine(finalcommand);
            // 

            MessageBox.Show("SOLUTION SUCCESSFULLY BUILT IN CURRENT DIRECTORY ");
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
