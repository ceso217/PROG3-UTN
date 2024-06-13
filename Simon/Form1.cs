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
using System.Text.Json;

namespace Simon
{
    public enum Colores { green = 1, red = 2, blue = 3, yellow = 4 }
    public partial class Form1 : Form
    {
        enum Estados { creandoSecuencia, mostrandoSecuencia, jugando, comparando, finDelJuego }
        Estados estadoActual = Estados.creandoSecuencia;
        int seg = 0;
        int puntaje = 0;

        public Form1()
        {
            InitializeComponent();
        }

        // eventos para iluminar botones
        int contador1 = 0;
        int contador2 = -1;
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
            Enlighten(button, offColor, onColor);
            if (contador1 == 2)
            {
                contador1 = 0;
                timerJuego.Tick -= eventHandler;
                timerSecuencia.Tick -= eventHandler;
                timerSecuencia.Stop();
                buttonOn();
            }
        }

        public void Enlighten(Button b, Color off, Color on)
        {
            if (b.BackColor == off)
            {
                b.BackColor = on;
            }
            else
            {
                b.BackColor = off;
            }
        }

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

        // eventos de botones

        private void buttonGreen_Click(object sender, EventArgs e)
        {
            buttonOff();
            timerSecuencia.Tick += greenEvent;
            timerSecuencia.Start();
            agregarInt(Colores.green);
        }

        private void buttonRed_Click(object sender, EventArgs e)
        {
            buttonOff();
            timerSecuencia.Tick += redEvent;
            timerSecuencia.Start();
            agregarInt(Colores.red);
        }

        private void buttonBlue_Click(object sender, EventArgs e)
        {
            buttonOff();
            timerSecuencia.Tick += blueEvent;
            timerSecuencia.Start();
            agregarInt(Colores.blue);
        }

        private void buttonYellow_Click(object sender, EventArgs e)
        {
            buttonOff();
            timerSecuencia.Tick += yellowEvent;
            timerSecuencia.Start();
            agregarInt(Colores.yellow);
        }

        // timer general del juego
        private void timerJuego_Tick(object sender, EventArgs e)
        {
            seg++;
            labelPuntaje.Text = $"Puntaje: {puntaje.ToString()}";
            if (estadoActual == Estados.creandoSecuencia)
            {
                cargarPuntaje();
                //textBox2.Text = cargarPuntaje();
                label3.Text = "Creando la secuencia!";
                crearSec();
                estadoActual = Estados.mostrandoSecuencia;
                seg = -1;
            }
            else if (estadoActual == Estados.mostrandoSecuencia)
            {
                mostrarSecuenciaGrafica();
                label3.Text = "Mostrando secuencia!";
                if (seg > secuencia.Count)
                {
                    timerSecuencia.Stop();
                    estadoActual = Estados.jugando;
                    timerSecuencia.Tick -= eventoSecuencia;
                    buttonOn();
                }
            }
            else if (estadoActual == Estados.jugando)
            {
                label3.Text = "Es tu turno de jugar!";
                if (secuencia.Count == secuenciaJugador.Count)
                {
                    estadoActual = Estados.comparando;
                }
            }
            else if (estadoActual == Estados.comparando)
            {
                label3.Text = "Comprobando el resultado :D";
                estadoActual = Estados.creandoSecuencia;
                comparar();
            }
            else if (estadoActual == Estados.finDelJuego)
            {
                cargarPuntaje();
                //textBox2.Text = cargarPuntaje();
                label3.Text = "Fin del juego! Gracias por jugar <3";
            }
        }

        int contador3 = -1;

        private void eventoSecuencia(object sender, EventArgs e)
        {
            contador2++;
            //label4.Text = contador2.ToString();

            if (seg < secuencia.Count && contador2 % 2 == 0)
            {
                switch (secuencia[seg])
                {
                    case Colores.green:
                        timerSecuencia.Tick += greenEvent;
                        break;
                    case Colores.red:
                        timerSecuencia.Tick += redEvent;
                        break;
                    case Colores.blue:
                        timerSecuencia.Tick += blueEvent;
                        break;
                    case Colores.yellow:
                        timerSecuencia.Tick += yellowEvent;
                        break;
                }
            }
        }

        // métodos para las funciones y mecánicas del juego
        List<Colores> secuencia = new List<Colores> { };
        List<Colores> secuenciaJugador = new List<Colores> { };

        public void mostrarSecuenciaGrafica()
        {
            buttonOff();
            if (seg == 0)
            {
                timerSecuencia.Tick += eventoSecuencia;
            }
            timerSecuencia.Start();
        }
        public void crearSec()
        {
            Random color = new Random();
            Colores color1 = (Colores)color.Next(1, 5);
            secuencia.Add(color1);
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
                    secuenciaJugador.Clear();
                    puntaje++;
                }
                else
                {
                    label1.Text = "Perdiste :(";
                    estadoActual = Estados.finDelJuego;
                    button1.Enabled = true;
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

        FileInfo score = new FileInfo(@"C:\Users\baron\source\repos\UTN-PROG3\Simon\datos.txt");
        List<Jugador> jugadores = new List<Jugador>();
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            textBox1.Enabled = false;

            // persistencia de archivo con .json
            jugadores.Add(new Jugador(textBox1.Text, puntaje));

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(jugadores, options);
            File.WriteAllText("jugadores.json", jsonString);

            // persistencia de archivos con .txt
            //using (FileStream fsw = score.Open(FileMode.Append, FileAccess.Write))
            //{
            //    using (StreamWriter sw = new StreamWriter(fsw))
            //    {
            //        sw.WriteLine($"{textBox1.Text} Puntaje: {puntaje} \r\n ");
            //    }
            //}
            puntaje = 0;
            textBox1.Text = string.Empty;
        }

        public void cargarPuntaje()
        {
            // persistencia de archivo con .json
            string jsonString = File.ReadAllText("jugadores.json");
            //var lista = JsonSerializer.Deserialize<List<Jugador>>(jsonString);
            jugadores = JsonSerializer.Deserialize<List<Jugador>>(jsonString);
            textBox2.Text = string.Empty;
            foreach (var jugador in jugadores)
            {
                textBox2.Text += $"{jugador.Nombre} Puntaje: {jugador.Puntaje} \r\n";
            }

            // persistencia de archivos con .txt
            //string linea = null;
            //string datos = "";
            //using (FileStream fsr = score.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite))
            //{
            //    using (StreamReader reader = new StreamReader(fsr))
            //    {
            //        while ((linea = reader.ReadLine()) != null)
            //        {
            //            datos += linea + "\r\n";
            //        }
            //        return datos;
            //    }
            //}
        }

        class Jugador
        {
            public string Nombre { get; set; }
            public int Puntaje { get; set; }

            public Jugador(string Nombre, int Puntaje)
            {
                this.Nombre = Nombre;
                this.Puntaje = Puntaje;
            }
        }
    }
}