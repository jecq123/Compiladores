using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compilador
{
    public partial class Form1 : Form
    {
        int contador = 0;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (contador == 0) {
                groupBox2.Hide();
            }
            else if (contador == 1) {
                groupBox2.Show();
                        }

            contador = contador + 1;
            if (contador == 2) contador = 0;
        }

        private void procesarTexto()
        {
            Cache cache = Cache.GetInstance();
            if (contador == 0)
            {
                
                for (int i = 0; i < textBox1.Lines.Length; i++)
                {
                    Linea linea = new Linea();
                    linea.lineaNumero = i + 1;
                    linea.lineaTexto = textBox1.Lines[i];
                    cache.AgregarValoresDiccionario(linea);
                }
            }
            else if (contador == 1)
            {
                string[] lineas = System.IO.File.ReadAllLines(label1.Text);
                int lineaNumero = 0;
                foreach (string line in lineas)
                {
                    Linea linea = new Linea();
                    linea.lineaNumero = lineaNumero+1 ;
                    linea.lineaTexto = line;
                    cache.AgregarValoresDiccionario(linea);
                    lineaNumero++;
                }
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Cache cache = Cache.GetInstance();
            cache.TheDictionary.Clear();
            textBox2.Text = String.Empty; 
            procesarTexto();
            foreach (KeyValuePair<int, string> entry in cache.TheDictionary)
            {
                textBox2.AppendLine(entry.Key+">> "+entry.Value);
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

       

        
    }
    public static class WinFormsExtensions
    {
        public static void AppendLine(this TextBox source, string value)
        {
            if (source.Text.Length == 0)
                source.Text = value ;
            else
                source.AppendText("\r\n"+value);
        }
    }
}
