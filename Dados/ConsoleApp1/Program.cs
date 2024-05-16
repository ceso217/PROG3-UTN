using System;

class Program
{
    static void Main(string[] args)
    {
        Casino casino = new Casino();
        int numeroWin;
        string jugar = "s";
        Console.WriteLine("Los montos iniciales de cada jugador son:\n Jugador 1: $" + casino.Jugadores[0].Dinero + "\t Jugador 2: $" + casino.Jugadores[1].Dinero);
        Console.WriteLine($"El pozo total del casino es de: ${casino.Pozo}");
        do
        {
            Console.WriteLine("Los modos de apuesta son:\n1. Conservador (-1/2)\n2. Arriesgado (-2/5)\n3. Desesperado (-4/15) ");
            for (int i = 0; i < casino.Jugadores.Length; i++)
            {
                Console.WriteLine("JUGADOR " + (i + 1) + ": ");
                do
                {
                    Console.WriteLine("Ingrese el modo que desea: ");
                    //casino.Jugadores[i].ModoApuesta = 1;
                    casino.Jugadores[i].ModoApuesta = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese el monto que desea: ");
                    //casino.Jugadores[i].Apuesta = 5;
                    casino.Jugadores[i].Apuesta = int.Parse(Console.ReadLine());
                } while (!casino.puedeApostar(casino.Jugadores[i]));
                Console.WriteLine("Ingrese el número al que apuesta: ");
                //casino.Jugadores[i].NumApuesta = 6;
                casino.Jugadores[i].NumApuesta = int.Parse(Console.ReadLine());
            }
            numeroWin = casino.lanzarDados();
            Console.WriteLine("El número sumado de los dados que salió es " + numeroWin + "!");
            for (int i = 0; i < casino.Jugadores.Length; i++)
            {
                if (numeroWin == casino.Jugadores[i].NumApuesta)
                {
                    Console.WriteLine("El Jugador " + (i + 1) + " acertó!");
                    casino.Jugadores[i].Apuesta *= 1;
                }
                else
                {
                    Console.WriteLine("El Jugador " + (i + 1) + " no acertó :(");
                    casino.Jugadores[i].Apuesta *= -1;
                }
                casino.Jugadores[i].Dinero = casino.resultadoApuesta(casino.Jugadores[i]);
            }
            Console.WriteLine("Los montos actuales de cada jugador son:\n Jugador 1: $" + casino.Jugadores[0].Dinero + "\t Jugador 2: $" + casino.Jugadores[1].Dinero);
            if (casino.Jugadores[0].Dinero > 0 && casino.Jugadores[1].Dinero > 0)
            {
                Console.WriteLine("Quiere seguir jugando? s/n");
                jugar = Console.ReadLine();
            }
        } while (jugar == "s" && casino.Jugadores[0].Dinero > 0 && casino.Jugadores[1].Dinero > 0 && casino.Pozo > 0);
        if (casino.Jugadores[0].Dinero <= 0)
        {
            Console.WriteLine("El Jugador 1 quedó en bancarrota :( :(");
        }
        if (casino.Jugadores[1].Dinero <= 0)
        {
            Console.WriteLine("El Jugador 2 quedó en bancarrota :( :(");
        }
        if (casino.Pozo <= 0)
        {
            Console.WriteLine("Ganaron todo el dinero del casino! FELICIDADES!");
        }
        Console.WriteLine($"Prosupuesto final:\n Jugador 1: ${casino.Jugadores[0].Dinero} \t Jugador 2: ${casino.Jugadores[1].Dinero} \t Pozo del casino: ${casino.Pozo}");
        Console.WriteLine("Gracias por jugar!");
    }
}

class Casino
{
    public Random dado;
    public int Pozo { get; set; }
    public Jugador [] Jugadores { get; set; }

    public Casino()
    {
        this.dado = new Random();
        this.Pozo = 10000;
        this.Jugadores = new Jugador[] { new Jugador(), new Jugador() };
    }
    public int lanzarDados()
    {
        return dado.Next(1, 7) + dado.Next(1, 7);
    }

    public int resultadoApuesta(Jugador jug)
    {
        switch (jug.ModoApuesta)
        {
            case 1:
                if (jug.Apuesta < 1)
                {
                    return jug.Dinero + jug.Apuesta;
                }
                else
                {
                    return jug.Dinero + (jug.Apuesta * 2);
                }
                break;
            case 2:
                if (jug.Apuesta < 1)
                {
                    return jug.Dinero + (jug.Apuesta * 2);
                }
                else
                {
                    return jug.Dinero + (jug.Apuesta * 5);
                }
                break;
            case 3:
                if (jug.Apuesta < 1)
                {
                    return jug.Dinero + (jug.Apuesta * 4);
                }
                else
                {
                    return jug.Dinero + (jug.Apuesta * 15);
                }
                break;
            default:
                return 0;
                break;
        }
    }

    public bool puedeApostar(Jugador jug)
    {
        jug.Apuesta *= -1;
        if (resultadoApuesta(jug) < 0)
        {
            Console.WriteLine("No tiene esa cantidad de dinero para apostar en el modo de apuesta que eligió");
            return false;
        }
        jug.Apuesta *= -1;
        return true;
    }
}

class Jugador
{
    public int Dinero { get; set; }
    public int NumApuesta { get; set; }
    public int Apuesta { get; set; }
    public int ModoApuesta { get; set; }

    public Jugador()
    {
        this.Dinero = 100;
        this.NumApuesta = 0;
        this.Apuesta = 0;
        this.ModoApuesta = 0;
    }
}


