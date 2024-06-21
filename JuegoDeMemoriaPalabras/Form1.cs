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

namespace JuegoDeMemoriaPalabras
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            manejadorDeClick(panel1);
        }
        enum Estados { mezclar, jugando, comprobando, finJuego }

        Estados estadoActual = Estados.mezclar;

        //List<String> pares = new List<String> { "casa", "abuela", "pelota", "avión", "pez", "manzana", "mate", "caramelo", "caja", "perro", "casa", "abuela", "pelota", "avión", "pez", "manzana", "mate", "caramelo", "caja", "perro" };
        List<String> pares = new List<String> { };
        List<String> paresRnd = new List<String> { };
        int boton1;
        int boton2;
        int controlesPresionados = 0;
        int movimietos = 15;
        Random rnd = new Random();
        public void mezclarLista()
        {
            while (pares.Count > 0)
            {
                int i = rnd.Next(0, pares.Count);
                paresRnd.Add(pares[i]);
                pares.Remove(pares[i]);
            }
        }
        public void manejadorDeClick(Panel panel)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is Button)
                {
                    control.Click += button_Click;
                }
            }
        }
        private void button_Click(object sender, EventArgs e)
        {
            Button boton = sender as Button;
            if (controlesPresionados == 0)
            {
                boton1 = panel1.Controls.IndexOf(boton);
                //panel1.Controls[boton1].Enabled = false;
                boton.Text = paresRnd[boton1];
            }
            else
            {
                boton2 = panel1.Controls.IndexOf(boton);
                //panel1.Controls[boton2].Enabled = false;
                boton.Text = paresRnd[boton2];
            }
            boton.Click -= button_Click;
            boton.BackColor = Color.PeachPuff;
            controlesPresionados++;
        }

        public void desactivarBotones()
        {
            foreach (Button buton in panel1.Controls)
            {
                buton.Enabled = false;
            }
        }

        public void activarBotones()
        {
            foreach (Button buton in panel1.Controls)
            {
                buton.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //var options = new JsonSerializerOptions { WriteIndented = true };
            //string jsonString = JsonSerializer.Serialize(paresRnd, options);
            //File.WriteAllText("pares.txt",jsonString);
            label1.Text = $"Movimientos restantes: {movimietos}";
            if (estadoActual == Estados.mezclar)
            {
                string jsonString = File.ReadAllText("pares.txt");
                pares = JsonSerializer.Deserialize<List<String>>(jsonString);
                mezclarLista();
                if (paresRnd.Count == 20)
                {
                    panel1.Enabled = true;
                    estadoActual = Estados.jugando;
                }
            }
            else if (estadoActual == Estados.jugando)
            {
                label3.Text = estadoActual.ToString();
                if (controlesPresionados == 2)
                {
                    estadoActual = Estados.comprobando;
                }
            }
            else if (estadoActual == Estados.comprobando)
            {
                controlesPresionados = 0;
                label3.Text = estadoActual.ToString();
                if (paresRnd[boton1] == paresRnd[boton2])
                {
                    panel1.Controls[boton1].Enabled = false;
                    panel1.Controls[boton2].Enabled = false;
                    textBox1.Text += paresRnd[boton1].ToString() + "\r\n";
                    movimietos--;
                    estadoActual = Estados.jugando;
                }
                else
                {
                    panel1.Controls[boton1].Click += button_Click;
                    panel1.Controls[boton2].Click += button_Click;
                    foreach (Button boton in panel1.Controls)
                    {
                        if (boton.Enabled)
                        {
                            boton.BackColor = Color.Coral;
                            boton.Text = string.Empty;
                        }
                    }
                    movimietos--;
                    estadoActual = Estados.jugando;
                }
                if (movimietos == 0)
                {
                    estadoActual = Estados.finJuego;
                }
            }
            else if (estadoActual == Estados.finJuego)
            {
                label3.Text = estadoActual.ToString();
                timer1.Stop();

                foreach (Button boton in panel1.Controls)
                {
                    if (boton.Enabled)
                    {
                        boton.Text = paresRnd[panel1.Controls.IndexOf(boton)];
                        boton.BackColor = Color.LightCoral;
                        boton.Enabled = false;
                    }
                }
            }
        }
    }
}
