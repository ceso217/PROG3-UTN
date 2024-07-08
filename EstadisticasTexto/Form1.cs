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
        List<string> palabrasCantidad = new List<string>();
        bool unaVez = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            int letras = 0;
            palabrasCantidad = textBox1.Text.Split(new char[] { ',', ' ', '.' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (char c in textBox1.Text)
            {
                if (c != ' ' && c != ',' && c != '.')
                {
                    letras++;
                }
            }

            label1.Text = $"Palabras: {palabrasCantidad.Count} Letras: {letras}";

            if (unaVez && letras > 0)
            {
                contarPalabras();
                armarRanking();
                unaVez = false;
            }
        }

        // contar repeticiones de palabras
        List<Palabra> palabrasApariciones = new List<Palabra>();
        public void contarPalabras()
        {
            bool esta;
            int apar;
            foreach (String p in palabrasCantidad)
            {
                esta = false;
                apar = 0;
                foreach (Palabra pal in palabrasApariciones)
                {
                    if (p == pal.Word)
                    {
                        esta = true;
                    }
                }
                if (!esta)
                {
                    foreach (String s in palabrasCantidad)
                    {
                        if (p == s)
                        {
                            apar++;
                        }
                    }
                    palabrasApariciones.Add(new Palabra(p, apar));
                }
            }
        }

        //armar Ranking
        List<Palabra> ranking = new List<Palabra>();
        public void ordenarRanking()
        {
            float mayor = 1;
            int index = 0;
            bool esta;
            for (int i = 0; i < 10; i++)
            {
                foreach (Palabra p in palabrasApariciones)
                {
                    esta = false;
                    if (p.Apariciones > mayor)
                    {
                        foreach (Palabra r in ranking)
                        {
                            if (p.Word == r.Word)
                            {
                                esta = true;
                            }
                        }
                        if (!esta)
                        {
                            mayor = p.Apariciones;
                            index = palabrasApariciones.IndexOf(p);
                        }
                    }
                }
                ranking.Add(palabrasApariciones[index]);
                mayor = 1;
            }
        }
        public void armarRanking()
        {
            ordenarRanking();
            for (int i = 0; i < 10; i++)
            {
                dataGridView1.Rows.Add(i + 1, ranking[i].Word, ranking[i].Word.Length, $"%{((ranking[i].Apariciones/palabrasCantidad.Count)*100):F1}", ranking[i].Apariciones);
            }
        }
    }
}

class Palabra
{
    public string Word { get; set; }
    public float Apariciones { get; set; }

    public Palabra(string word, int apariciones)
    {
        this.Word = word;
        this.Apariciones = apariciones;
    }
}