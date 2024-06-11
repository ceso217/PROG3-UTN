using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simon
{
    public enum Colores { green = 1, red = 2, blue = 3, yellow = 4 }
    public partial class Form1 : Form
    {
        int seg = 0;

        public Form1()
        {
            InitializeComponent();
        }

        // eventos para iluminar botones
        int contador1 = 0;
        int contador2 = -1;
        bool apagado = true;
        private void blueEvent(object sender, EventArgs e)
        {
            HandleEvent(buttonBlue, Color.MidnightBlue, Color.Blue, blueEvent);
        }
        private void greenEvent(object sender, EventArgs e)
        {
            HandleEvent(buttonGreen, Color.DarkOliveGreen, Color.Lime, greenEvent);
        }
        private void redEvent(object sender, EventArgs e)
        {
            HandleEvent(buttonRed, Color.Maroon, Color.Red, redEvent);
        }
        private void yellowEvent(object sender, EventArgs e)
        {
            HandleEvent(buttonYellow, Color.Goldenrod, Color.Yellow, yellowEvent);
        }
        private void HandleEvent(Button button, Color offColor, Color onColor, EventHandler eventHandler)
        {
            contador1++;
            Enlighten(button, offColor, onColor, ref apagado);
            label2.Text = contador1.ToString();
            label3.Text = apagado.ToString();
            if (contador1 == 2)
            {
                contador1 = 0;
                timerJuego.Tick -= eventHandler;
                timer1.Tick -= eventHandler;
                timer1.Stop();
                buttonOn();
            }
        }

        public void Prenderse()
        {

        }

        //public void Enlighten(Button b, Color off, Color on, ref bool apagado)
        //{
        //    if (apagado)
        //    {
        //        b.BackColor = on;
        //        apagado = false;
        //    }
        //    else
        //    {
        //        b.BackColor = off;
        //        apagado = true;
        //    }
        //}

        public void buttonOff()
        {
            buttonBlue.Enabled = false;
            buttonGreen.Enabled = false;
            buttonRed.Enabled = false;
            buttonYellow.Enabled = false;
        }

        public void buttonOn()
        {
            buttonBlue.Enabled = true;
            buttonGreen.Enabled = true;
            buttonRed.Enabled = true;
            buttonYellow.Enabled = true;
        }

        public void sequencEvent(object sender, EventArgs e)
        {
            contador2++;
            if (apagado)
            {
                if (contador2 < secuencia.Count)
                {
                    switch (secuencia[contador2])
                    {
                        case Colores.green:
                            timer1.Start();
                            timer1.Tick += greenEvent;
                            break;
                        case Colores.red:
                            timer1.Start();
                            timer1.Tick += redEvent;
                            break;
                        case Colores.blue:
                            timer1.Start();
                            timer1.Tick += blueEvent;
                            break;
                        case Colores.yellow:
                            timer1.Start();
                            timer1.Tick += yellowEvent;
                            break;
                    }
                    label4.Text = contador2.ToString();
                }
                if(contador2==secuencia.Count+1)
                {
                    buttonOn();
                    //timer1.Stop();
                    contador2 = -1;
                    timerJuego.Enabled = true;
                }
            }
        }

        // eventos de botones

        bool buttonPres = true;
        private void buttonGreen_Click(object sender, EventArgs e)
        {
            buttonOff();
            buttonPres = true;
            timerJuego.Tick += greenEvent;
            agregarInt(Colores.green);
        }

        private void buttonRed_Click(object sender, EventArgs e)
        {
            buttonOff();
            buttonPres = true;
            timerJuego.Tick += redEvent;
            agregarInt(Colores.red);
        }

        private void buttonBlue_Click(object sender, EventArgs e)
        {
            buttonOff();
            buttonPres = true;
            timerJuego.Tick += blueEvent;
            agregarInt(Colores.blue);
        }

        private void buttonYellow_Click(object sender, EventArgs e)
        {
            buttonOff();
            buttonPres = true;
            timerJuego.Tick += yellowEvent;
            agregarInt(Colores.yellow);
        }

        // timer general del juego
        private void timerJuego_Tick(object sender, EventArgs e)
        {
            seg++;
            labelTimer.Text = seg.ToString();
            labelSecuencia.Text = mostrarSecuencia();
            labelSecuenciaJugador.Text = mostrarSecuenciaJugador();
            comparar();
            if (buttonPres)
            {
                if (secuencia.Count != secuenciaJugador.Count)
                {
                    if (acerto)
                    {
                        label1.Text = "Ingrese la secuencia";
                    }
                }
                else
                {
                    if (acerto)
                    {
                        crearSec();
                        labelSecuencia.Text = mostrarSecuencia();
                        mostrarSecuenciaGrafica();
                        acerto = false;
                        buttonPres = false;
                        secuenciaJugador.Clear();
                        label1.Text = "SIMON";
                    }
                }
            }
        }

        // métodos para las funciones y mecánicas del juego
        List<Colores> secuencia = new List<Colores> { };
        List<Colores> secuenciaJugador = new List<Colores> { };
        bool acerto = true;

        public void mostrarSecuenciaGrafica()
        {
            buttonOff();
            timerJuego.Enabled = false;
            timer1.Start();
        }
        public void crearSec()
        {
            Random color = new Random();
            if (acerto)
            {
                Colores color1 = (Colores)color.Next(1, 5);
                secuencia.Add(color1);
            }
        }
        public void agregarInt(Colores c)
        {
            secuenciaJugador.Add(c);
        }

        public void comparar()
        {
            if (secuencia.Count == secuenciaJugador.Count)
            {
                if (mostrarSecuencia() == mostrarSecuenciaJugador())
                {
                    acerto = true;
                }
                else
                {
                    label1.Text = "Perdiste :(";
                    timerJuego.Stop();
                }
            }
        }

        public string mostrarSecuencia()
        {
            string resultado = "";

            foreach (Colores c in secuencia)
            {
                resultado = resultado + c.ToString() + "\n";
            }

            return resultado;
        }

        public string mostrarSecuenciaJugador()
        {
            string resultado = "";

            foreach (Colores c in secuenciaJugador)
            {
                resultado = resultado + c.ToString() + "\n";
            }

            return resultado;
        }
    }

    class BotonColor
    {
        public Color ColorPrendido { get; set; }
        public Color ColorApagado { get; set; }
    }

    class BotonRojo : BotonColor
    {
        public BotonRojo()
        {
            ColorPrendido = Color.Red;
            ColorApagado = Color.Maroon;
        }
    }

    class BotonVerde : BotonColor
    {
        public BotonVerde()
        {
            ColorPrendido = Color.Lime;
            ColorApagado = Color.DarkOliveGreen;
        }
    }

    class BotonAzul : BotonColor
    {
        public BotonAzul()
        {
            ColorPrendido = Color.Blue;
            ColorApagado = Color.MidnightBlue;
        }
    }

    class BotonAmarillo : BotonColor
    {
        public BotonAmarillo()
        {
            ColorPrendido = Color.Yellow;
            ColorApagado = Color.Goldenrod;
        }
    }
}