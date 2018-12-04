using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace SpringfieldChallenge
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            bool flag = true;
            String[] filename = new String[1000]; 
            this.richTextBox1.Show();
            this.richTextBox1.Hide();
            this.richTextBox2.Show();
            if(flag)
            {
                this.openFileDialog1.ShowDialog();
                filename =  this.openFileDialog1.FileNames;
                flag = false;
            }
            
           
            this.richTextBox3.BringToFront();
            this.richTextBox2.Hide();
            this.richTextBox3.Show();
            this.trackBar1.Show();    
            
            
            

        }
    }
}
