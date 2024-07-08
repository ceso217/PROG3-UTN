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

namespace generadorDeTexto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] palabras = File.ReadAllText(@"C:\Users\baron\Desktop\textolatin.txt").Split(new char[] { ',', '.', ' ', ':', '?', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        // generar texto

        Random rnd = new Random();
        bool lorem = false;
        int cantidadParrafos;
        int cantidadPalabrasTexto;

        private void button1_Click(object sender, EventArgs e)
        {

            int cantidadPalabrasOracion;

            int cantidadOracionesParrafo;

            string texto = "";

            bool primera = true;

            if (lorem)
            {
                texto = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            }
            // si selecciono cantidad de palabras
            if (numericUpDownPalabras.Enabled)
            {
                // si selecciona cantidad de palabras
                while (cantidadPalabrasTexto > 0)
                {
                    // armado de parrafos (oraciones por parrafo)
                    cantidadOracionesParrafo = rnd.Next(1, Convert.ToInt32(numericUpDown3.Value + 1));
                    for (int i = 0; i < cantidadOracionesParrafo; i++)
                    {
                        // armado de oraciones (palabras por oracion)
                        if (cantidadPalabrasTexto > Convert.ToInt32(numericUpDown1.Value) + Convert.ToInt32(numericUpDown2.Value + 1))
                        {
                            cantidadPalabrasOracion = rnd.Next(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value + 1));
                        }
                        else
                        {
                            if (cantidadPalabrasTexto < Convert.ToInt32(numericUpDown2.Value))
                            {
                                cantidadPalabrasOracion = cantidadPalabrasTexto;
                            }
                            else
                            {
                                cantidadPalabrasOracion = Convert.ToInt32(numericUpDown1.Value);
                            }
                        }
                        for (int j = 0; j < cantidadPalabrasOracion; j++)
                        {
                            if (cantidadPalabrasTexto > 0)
                            {
                                string palabra = palabras[rnd.Next(0, palabras.Length)];
                                if (primera)
                                {
                                    palabra = char.ToUpper(palabra[0]) + palabra.Substring(1);
                                    primera = false;
                                }
                                texto += " " + palabra;

                                cantidadPalabrasTexto--;
                            }
                        }
                        texto += ". ";
                        primera = true;
                        if (cantidadPalabrasTexto == 0)
                        {
                            break;
                        }
                    }
                    texto += "(SALTO)\n\n";
                }
            }

            // si selecciono cantidad de parrafos
            if (numericUpDownParrafos.Enabled)
            {
                // si selecciona cantidad de palabras
                while (cantidadParrafos > 0)
                {
                    // armado de parrafos (oraciones por parrafo)
                    cantidadOracionesParrafo = rnd.Next(1, Convert.ToInt32(numericUpDown3.Value + 1));
                    for (int i = 0; i < cantidadOracionesParrafo; i++)
                    {
                        // armado de oraciones (palabras por oracion)
                        cantidadPalabrasOracion = rnd.Next(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value + 1));
                        for (int j = 0; j < cantidadPalabrasOracion; j++)
                        {
                            string palabra = palabras[rnd.Next(0, palabras.Length)];
                            if (primera)
                            {
                                palabra = char.ToUpper(palabra[0]) + palabra.Substring(1);
                                primera = false;
                            }
                            texto += " " + palabra;
                        }
                        texto += ". ";
                        primera = true;
                    }
                    texto += "(SALTO)\n\n";
                    cantidadParrafos--;
                }
            }

            richTextBox1.Text = texto;
            string[] cantPalabras = texto.Split(new char[] { '\n', '.', ' ', '*' }, StringSplitOptions.RemoveEmptyEntries);
            label7.Text = $"Cantidad de palabras: {cantPalabras.Length}";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < palabras.Length; i++)
            {
                palabras[i] = palabras[i].ToLower();
            }

            if (numericUpDownParrafos.Value != 0)
            {
                cantidadParrafos = (int)numericUpDownParrafos.Value;
                numericUpDownPalabras.Enabled = false;
            }
            else
            {
                cantidadParrafos = rnd.Next(1, 6);
                numericUpDownPalabras.Enabled = true;
            }

            if (numericUpDownPalabras.Value != 0)
            {
                cantidadPalabrasTexto = (int)numericUpDownPalabras.Value;
                numericUpDownParrafos.Enabled = false;
            }
            else
            {
                cantidadPalabrasTexto = rnd.Next(60, 301);
                numericUpDownParrafos.Enabled = true;
            }

            if (checkBox1.Checked)
            {
                lorem = true;
                cantidadPalabrasTexto -= 8;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.WriteAllText("textoAutogenerado.txt", richTextBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = File.ReadAllText("textoAutogenerado.txt");
        }
    }
}
