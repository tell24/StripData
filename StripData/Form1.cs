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

            if (textBox2.TextLength > 0) button2.Enabled = true;


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
            textBox3.Text = lines.ToString();
            textBox3.Update();

            Single gap = lines / Int16.Parse(textBox4.Text);
            int rl = 0;
            int ol = 0;
            using (StreamWriter sw = new StreamWriter(textBox2.Text))
            {
                sr = new StreamReader(textBox1.Text);
                //Read the first line of text
                line = sr.ReadLine();
                if (radioButton1.Checked)
                    sw.WriteLine(line);
                else
                {
                    if (line != null)
                    {
                        String[] split = line.Split('\t');

                        sw.WriteLine(split[1]);
                    }
                }
                rl++;
                //Continue to read until you reach end of file
                while (line != null)
                {
                    ol++;
                    while (ol < (rl * gap)) {
                        line = sr.ReadLine();
                        ol++;
                    }

                    line = sr.ReadLine();
                    if (radioButton1.Checked)
                        sw.WriteLine(line);
                    else
                    {
                        if (line != null)
                        {
                            String[] split = line.Split('\t');

                            sw.WriteLine(split[1]);
                        }
                    }
                    rl++;
                }

                //close the file
                sr.Close();
                sw.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            textBox2.Text = saveFileDialog1.FileName;
            if (textBox1.TextLength > 0) button2.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
