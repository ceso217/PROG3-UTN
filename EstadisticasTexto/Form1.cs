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

namespace EstadisticasTexto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // selección del texto del archivo
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.ShowDialog();

            string path = openFile.FileName;

            textBox1.Text = File.ReadAllText(path);
        }

        // conteo de palabras y letras
        private void timer1_Tick(object sender, EventArgs e)
        {
            int letras = 0;
            string[] palabras = textBox1.Text.Split(new char[] { ',', ' ', '.' },StringSplitOptions.RemoveEmptyEntries);

            foreach(char c in textBox1.Text)
            {
                if(c != ' ')
                {
                    letras++;
                }
            }

            label1.Text = $"Palabras: {palabras.Length} Letras: {letras}";
        }








    }
}
