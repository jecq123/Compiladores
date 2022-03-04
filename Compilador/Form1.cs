using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Compilador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

       

        private void procesarTexto()
        {
            Cache cache = Cache.GetInstance();
            cache.Reset();
            if (rbtnText.Checked)
            {
                cache.AddLines(txtLines.Lines);
            }
            else if (rbtnFile.Checked)
            {
                if (label1.Text != "")
                {
                    string[] lines;

                    using (StreamReader sr = new StreamReader(label1.Text))
                    {
                        String file = sr.ReadToEnd();
                        lines = file.Split('\n');
                    }
                    cache.AddLines(lines);
                }
                
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Cache cache = Cache.GetInstance();
            cache.Reset();
            txtConsole.Text = String.Empty; 
            procesarTexto();
            foreach (KeyValuePair<int, string> entry in cache.GetLinesDictionary())
            {
                txtConsole.AddLine(entry.Key+">> "+entry.Value);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Archivos de texto (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                label1.Text = openFileDialog1.FileName;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnText.Checked)
            {
                groupBox2.Show();
                groupBox1.Hide();
            }
            else if (rbtnFile.Checked)
            {
                groupBox1.Show();
                groupBox2.Hide();
            }
        }

        private void txtLines_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbtnFile_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtConsole_TextChanged(object sender, EventArgs e)
        {

        }
    }
    public static class WinFormsExtensions
    {
        public static void AddLine(this TextBox source, string value)
        {
            if (source.Text.Length == 0)
                source.Text = value ;
            else
                source.AppendText("\r\n"+value);
        }
    }
}
