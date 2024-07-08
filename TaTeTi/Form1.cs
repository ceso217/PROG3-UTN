using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaTeTi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            manejadorBotones();
        }

        enum Estados { turnoJugador, turnoIA, comprobandoJugador, comprobandoIA, finJuego }

        Estados estadoActual = Estados.turnoJugador;
        int accion = 0;

        public void manejadorBotones()
        {
            foreach (Control c in panel1.Controls)
            {
                c.Click += button_Click;
            }
        }
        private void button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            btn.Text = "X";
            btn.Enabled = false;

            accion++;

            label4.Text += panel1.Controls.IndexOf(btn) + 1;
        }

        string resultado = "Resultado: Ganaste!";
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (estadoActual == Estados.turnoJugador)
            {
                resultado = "Resultado: Ganaste!";
                label1.Text = estadoActual.ToString();
                if (accion == 1)
                {
                    accion = 0;
                    estadoActual = Estados.comprobandoJugador;
                }
            }
            else if (estadoActual == Estados.comprobandoJugador)
            {
                label1.Text = estadoActual.ToString();
                if (comprobar("X"))
                {
                    estadoActual = Estados.finJuego;
                }
                else
                {
                    estadoActual = Estados.turnoIA;
                }
            }
            else if (estadoActual == Estados.turnoIA)
            {
                resultado = "Resultado: Perdiste! :(";
                label1.Text = estadoActual.ToString();
                estadoActual = Estados.comprobandoIA;
                movimientoIA();
            }
            else if (estadoActual == Estados.comprobandoIA)
            {
                label1.Text = estadoActual.ToString();
                if (comprobar("O"))
                {
                    estadoActual = Estados.finJuego;
                }
                else
                {
                    estadoActual = Estados.turnoJugador;
                }
            }
            else if (estadoActual == Estados.finJuego)
            {
                label1.Text = estadoActual.ToString();
                label2.Text = resultado;
                if(resultado== "Resultado: Ganaste!")
                {
                    panel1.Controls[g1].ForeColor = Color.ForestGreen;
                    panel1.Controls[g2].ForeColor = Color.ForestGreen;
                    panel1.Controls[g3].ForeColor = Color.ForestGreen;
                } else
                {
                    panel1.Controls[g1].ForeColor = Color.Red;
                    panel1.Controls[g2].ForeColor = Color.Red;
                    panel1.Controls[g3].ForeColor = Color.Red;
                }
            }
        }

        //comprobación
        List<int> casillasClave = new List<int>() { 2, 4, 5, 6, 8 };
        List<int> casillasGanadoras = new List<int>() { 6, 120, 504, 28, 80, 162, 105, 45 };
        int g1=0;
        int g2=0;
        int g3=0;
        public bool comprobar(string marca)
        {
            List<int> marcados = new List<int>();
            List<int> marcadosClave = new List<int>();
            for (int i = 0; i < panel1.Controls.Count; i++)
            {
                if (panel1.Controls[i].Text == marca)
                {
                    marcados.Add(i + 1);
                    for (int j = 0; j < casillasClave.Count; j++)
                    {
                        if (i == j)
                        {
                            marcadosClave.Add(j + 1);
                        }
                    }
                }
            }
            foreach (int numero1 in marcados)
            {
                foreach (int numero2 in marcados)
                {
                    foreach (int clave in marcadosClave)
                    {
                        foreach (int numeroGanador in casillasGanadoras)
                        {
                            if (clave * numero1 * numero2 == numeroGanador && numero1 != numero2 && numero1 != clave && numero2 != clave)
                            {
                                if (clave * numero1 * numero2 == 120 && (clave == 8 || numero1 == 8 || numero2 == 8))
                                {
                                    break;
                                }
                                    label3.Text = $" {numero1}  {clave}  {numero2}";
                                g1 = numero1;
                                g2 = numero2;
                                g3 = clave;
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        // comportamiento IA

        public void movimientoIA()
        {
            List<int> desmarcados = new List<int>();
            Random rnd = new Random();

            for (int i = 0; i < panel1.Controls.Count; i++)
            {
                if (panel1.Controls[i].Enabled)
                {
                    desmarcados.Add(i);
                }
            }

            if (desmarcados is null)
            {
                estadoActual = Estados.finJuego;
                resultado = "Empate";
            }
            else
            {
                int botonAMarcar = desmarcados[rnd.Next(0, desmarcados.Count)];

                panel1.Controls[botonAMarcar].Text = "O";
                panel1.Controls[botonAMarcar].Enabled = false;
            }
        }
    }
}
