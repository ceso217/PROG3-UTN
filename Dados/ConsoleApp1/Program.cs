using System;

class Program
{
    static void Main(string[] args)
    {
        Casino casino = new Casino();
        int numeroWin;
        string jugar="s";
        do
        {
            Console.WriteLine("Los jugadores tienen cada uno:\n Jugador 1: " + casino.Jugadores[0].Dinero + "\t Jugador 2: " + casino.Jugadores[1].Dinero);
            Console.WriteLine("Los modos de apuesta son:\n1. Conservador (-1/2)\n2. Arriesgado (-2/5)\n3. Desesperado (-4/15) ");
            for (int i = 0; i < casino.Jugadores.Count; i++)
            {
                Console.WriteLine("JUGADOR " + (i+1) + ": ");
                Console.WriteLine("Ingrese el modo que desea: ");
                //casino.Jugadores[i].ModoApuesta = 1;
                casino.Jugadores[i].ModoApuesta = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el monto que desea: ");
                //casino.Jugadores[i].Apuesta = 5;
                casino.Jugadores[i].Apuesta = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el número al que apuesta: ");
                //casino.Jugadores[i].NumApuesta = 6;
                casino.Jugadores[i].NumApuesta = int.Parse(Console.ReadLine());
            }
            numeroWin = casino.lanzarDados();
            Console.WriteLine("El número sumado de los dados que salió es " + numeroWin + "!");
            for (int i = 0; i < casino.Jugadores.Count; i++)
            {
                if (numeroWin == casino.Jugadores[i].NumApuesta)
                {
                    Console.WriteLine("El Jugador " + (i + 1) + " acertó!");
                    casino.Jugadores[i].Apuesta *= 1;
                }
                else
                {
                    Console.WriteLine("El Jugador " + (i+1) + " no acertó :(");
                    casino.Jugadores[i].Apuesta *= -1;
                }
                casino.resultadoApuesta(casino.Jugadores[i]);
            }
            Console.WriteLine("Quiere seguir jugando? s/n");
            jugar = Console.ReadLine();
        } while (jugar == "s" || casino.Jugadores[0].Dinero <= 0 || casino.Jugadores[1].Dinero <= 0);
        Console.WriteLine("Puntaje final:\n Jugador 1: " + casino.Jugadores[0].Dinero + "\t Jugador 2: " + casino.Jugadores[1].Dinero);
        Console.WriteLine("Gracias por jugar!");
    }
}

class Casino
{
    public Random dado;
    public int Pozo {  get; set; }
    public List<Jugador> Jugadores {  get; set; }

    public Casino()
    {
        this.dado = new Random();
        this.Pozo = 10000;
        this.Jugadores = new List<Jugador> { new Jugador(), new Jugador() };
    }
    public int lanzarDados()
    {
        return dado.Next(1,7)+dado.Next(1, 7);
    }

    public void resultadoApuesta(Jugador jug)
    {
        switch(jug.ModoApuesta){
            case 1:
                if (jug.Apuesta < 1)
                {
                    jug.Dinero += jug.Apuesta; 
                }
                else
                {
                    jug.Dinero += jug.Apuesta * 2;
                }
                break;
            case 2:
                if (jug.Apuesta < 1)
                {
                    jug.Dinero += jug.Apuesta * 2;
                }
                else
                {
                    jug.Dinero += jug.Apuesta * 5;
                }
                break;
            case 3:
                if (jug.Apuesta < 1)
                {
                    jug.Dinero += jug.Apuesta * 4;
                }
                else
                {
                    jug.Dinero += jug.Apuesta * 15;
                }
                break;
        }
    }
    /*public int modoApuesta(int modo, int gano)
    {
        switch(modo)
        {
            case 1:
                if(gano == 1)
                {
                    jugadores
                }
        }
    }*/
}

class Jugador
{
    public int Dinero { get; set; }
    public int NumApuesta {  get; set; }
    public int Apuesta {  get; set; }
    public int ModoApuesta { get; set; }

    public Jugador()
    {
        this.Dinero = 100;
        this.NumApuesta = 0;
        this.Apuesta = 0;
        this.ModoApuesta = 0;
    }
}


