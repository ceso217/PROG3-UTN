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
        int movimietos = 20;
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
                boton.Text = paresRnd[boton1];
            }
            else
            {
                boton2 = panel1.Controls.IndexOf(boton);
                boton.Text = paresRnd[boton2];
            }
            boton.BackColor = Color.PeachPuff;
            controlesPresionados++;
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
                    textBox1.Text += paresRnd[boton1].ToString()+"\r\n";
                    panel1.Controls[boton1].Enabled = false;
                    panel1.Controls[boton2].Enabled = false;
                    movimietos--;
                    estadoActual = Estados.jugando;
                }
                else
                {
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
                    boton.Enabled = false;
                }
            }
        }
    }
}
