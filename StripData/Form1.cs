using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StripData
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string line = "";
            int lines = 0;
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(textBox1.Text);
                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the lie to console window
                    //  Console.WriteLine(line);
                    lines++;//Read the next line
                    line = sr.ReadLine();
                }

                //close the file
                sr.Close();
                //   Console.ReadLine();
            textBox2.Text = lines.ToString();
        }
    }
}
