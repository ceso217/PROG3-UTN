using System;

class Program
{
    static void Main(string[] args)
    {
        Casino casino = new Casino();
        Jugador jugador1 = new Jugador();
        Jugador jugador2 = new Jugador();
        int numeroWin;
        List<Jugador> jugadores = new List<Jugador>(){jugador1,jugador2 };
        int gano = 0;

        Console.WriteLine("Los jugadores tienen cada uno:\n Jugador 1: "+jugador1.Dinero+"\t Jugador 2: "+jugador2.Dinero);
        for (int i = 0; i < jugadores.Count; i++)
        {
            Console.WriteLine("JUGADOR "+i+": ");
            Console.WriteLine("Ingrese el modo de apuesta que desea:\n1. Conservador (-1/2)\n2. Arriesgado (-2/5)\n 3. Desesperado (-4/15) ");
            Console.WriteLine("Ingrese el modo de apuesta que desea: ");
            jugadores[i].Modo=int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el monto que desea el Jugador 1: ");
            jugadores[i].Apuesta = int.Parse(Console.ReadLine());
        }
        numeroWin = casino.lanzarDados();
        Console.WriteLine("El número sumado de los dados que salió es "+numeroWin+"!");
        for (int i = 0; i < jugadores.Count; i++)
        {
            if (numeroWin == jugadores[i].Apuesta)
            {
                Console.WriteLine("El Jugador "+i+" acertó!");
                gano = 1;
            }
            else
            {
                Console.WriteLine("El Jugador "+i+" no acertó :(");
            }
        }
    }
}

class Casino
{
    public int Pozo {  get; set; }

    public Casino()
    {
        this.Pozo = 10000;
    }
    public int lanzarDados()
    {
        Dado dado = new Dado();
        return dado.dado.Next(1,7)+dado.dado.Next(1, 7);
    }

    public int modoApuesta(int modo, int gano)
    {
        switch(modo)
        {
            case 1:
                if(gano == 1)
                {
                    jugadores
                }
        }
    }
}
class Dado
{
    public Random dado = new Random();
}

class Jugador
{
    public int Dinero { get; set; }
    public int Modo { get; set; }
    public int Apuesta {  get; set; }

    public Jugador()
    {
        this.Apuesta = 0;
        this.Modo = 0;
        this.Dinero = 100;
    }
}


