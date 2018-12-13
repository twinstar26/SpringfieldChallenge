using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpringfieldChallenge
{
    public partial class Form0 : Form
    {
        public Form0()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            label1.Hide();
            label2.Hide();
            label3.Hide();
            button1.Hide();

            radioButton1.Show();
            radioButton2.Show();
            button2.Show();
            label5.Show();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                
                Form2 form2 = new Form2();
                form2.ShowDialog();
                Close();
            }
            else if(radioButton2.Checked)
            {
                
                Form1 form1 = new Form1();
                form1.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("PLEASE SHOW APPROPRIATE OPTION ");

            }
        }
    }
}
