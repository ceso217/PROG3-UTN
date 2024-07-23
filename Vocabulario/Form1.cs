using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Vocabulario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // listas de vocabulario
        List<Palabra> vocabulario = new List<Palabra>();
        List<Palabra> mostrados = new List<Palabra>();
        List<Palabra> acertadas = new List<Palabra>();

        // estados
        enum Estados {completar, cambiar, cargar }

        Estados estadoActual = Estados.cambiar;

        //agregar palabra nueva al vocabulario
        bool existe = false;
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Palabra p in vocabulario)
            {
                if (textBoxSignificado.Text == p.Significado)
                {
                    existe = true;
                    MessageBox.Show("Esta palabra ya fue añadida al vocabulario","Palabra existente",MessageBoxButtons.OK);
                    textBoxPalabra.Text = "";
                    textBoxSignificado.Text = "";
                }
            }
            if (!existe)
            {
                vocabulario.Add(new Palabra(textBoxPalabra.Text,textBoxSignificado.Text));
                textBoxPalabra.Text = "";
                textBoxSignificado.Text = "";
            }
            guardar();
        }
        // timer
        bool unaVez = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = $"Acertadas: {acerto}";
            label4.Text = $"Palabras restantes: {vocabulario.Count-acertadas.Count}";
            cargar();
            if(estadoActual== Estados.cambiar)
            {
                mostrarVocabulario();
                estadoActual = Estados.completar;
            }
            if (unaVez && vocabulario.Count==acertadas.Count)
            {
                unaVez = false;
                MessageBox.Show("Completaste el vocabulario!!!", "Vocabulario completado", MessageBoxButtons.OK);
            }
        }

        // mostrar vocabulario
        public void mostrarVocabulario()
        {
            bool agregar = true;
            Random rnd = new Random();
            for(int i = 0; i < 10; i++)
            {
                if(mostrados.Count < vocabulario.Count-acertadas.Count)
                {
                    int index = rnd.Next(0, vocabulario.Count);
                    foreach (Palabra p in mostrados)
                    {
                        if (vocabulario[index].Significado == p.Significado)
                        {
                            agregar = false;
                        }
                    }
                    foreach (Palabra p in acertadas)
                    {
                        if (vocabulario[index].Significado == p.Significado)
                        {
                            agregar = false;
                        }
                    }
                    if (agregar)
                    {
                        mostrados.Add(vocabulario[index]);
                        dataGridView1.Rows.Add(vocabulario[index].Palabraa, " ", "");
                    }
                    else
                    {
                        i--;
                        agregar = true;
                    }
                }
            }
        }

        string archivo = "vocabulario.txt";
        // guardar archivo
        public void guardar()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(vocabulario, options);
            File.WriteAllText(archivo, jsonString);
        }
        // cargar archivo
        public void cargar()
        {
            string jsonString = File.ReadAllText(archivo);
            if (jsonString != "")
            {
                vocabulario = JsonSerializer.Deserialize<List<Palabra>> (jsonString);
            }
        }

        // cambiar
        public void cambiar()
        {
            mostrados.Clear();
            dataGridView1.Rows.Clear();
            estadoActual = Estados.cambiar;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            cambiar();
        }

        // comprobar
        int acerto = 0;
        bool agregada = true;
        public void comprobar()
        {
            for (int i = 0; i < mostrados.Count; i++)
            {
                string aux = dataGridView1.Rows[i].Cells["Significado"].Value.ToString();
                if (mostrados[i].Significado == aux)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.ForestGreen;
                    foreach(Palabra p in vocabulario)
                    {
                        if (p.Significado == aux)
                        {
                            foreach (Palabra p2 in acertadas)
                            {
                                if(p2.Significado == aux)
                                {
                                    agregada = false;
                                }
                            }
                            if (agregada)
                            {
                                acertadas.Add(p);
                                acerto++;
                            }
                            agregada = true;
                        }
                    }
                }
                else
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    dataGridView1.Rows[i].Cells["Comprobacion"].Value = mostrados[i].Significado;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comprobar();
        }

        private void textBoxPalabra_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("ja-JP"));
        }
        // vocabulario1
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            archivo = "vocabulario.txt";
            label5.Text = "Vocabulario actual: 1";
            vocabulario.Clear();
            cambiar();
        }
        // vocabulario 2
        private void vocabulario2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            archivo = "vocabulario2.txt";
            label5.Text = "Vocabulario actual: 2";
            vocabulario.Clear();
            cambiar();
        }
        // vocabulario 3
        private void vocabulario3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            archivo = "vocabulario3.txt";
            label5.Text = "Vocabulario actual: 3";
            vocabulario.Clear();
            cambiar();
        }
        // vocabulario 4
        private void vocabulario4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            archivo = "vocabulario4.txt";
            label5.Text = "Vocabulario actual: 4";
            vocabulario.Clear();
            cambiar();
        }

        private void textBoxPalabra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita que el sonido de "ding" se reproduzca
                textBoxSignificado.Focus(); // Mueve el foco
            }
        }

        private void textBoxSignificado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                button1.Focus();
            }
        }
    }

    class Palabra
    {
        public string Palabraa {  get; set; }
        public string Significado { get; set; }
        public Palabra(string palabraa, string significado)
        {
            this.Palabraa = palabraa;
            this.Significado = significado;
        }
    }
}
