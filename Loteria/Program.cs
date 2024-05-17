using System;

class Program
{
    static void Main(string[] args)
    {
        Comercio comercio = new Comercio();
        Cliente cliente = new Cliente();

        comercio.SortearLoteria();
        comercio.mostrar();

        //cliente.Adivinar();
        cliente.mostrar();

        comercio.Comparar(cliente.Adivinanza);
    }
}

class Comercio
{
    public int[] Loteria { get; set; }

    public Comercio()
    {
        Loteria = new int[5] { -1, -1, -1, -1, -1 };
    }

    public void SortearLoteria()
    {
        Random r = new Random();
        int num = 0;
        bool existe;


        for (int i = 0; i < Loteria.Length; i++)
        {
            do
            {
                existe = false;
                num = r.Next(0, 51);
                foreach (int n in Loteria)
                {
                    if (n == num)
                    {
                        existe = true;
                    }
                }
                if (!existe)
                {
                    Loteria[i] = num;
                }
                else
                {
                    Console.WriteLine($"El número {num} ya salió");
                }
            } while (existe);
        }
    }

    public int Comparar(int[] Adivinanza)
    {
        int acerto = 0;
        foreach (int l in Loteria)
        {
            foreach(int a in Adivinanza)
            {
                if(l == a)
                {
                    acerto++;
                }
            }
        }

        Console.WriteLine($"El cliente acerto {acerto} números!");

        return acerto;
    }

    public void mostrar()
    {
        Console.WriteLine("Los números que salieron son:");
        foreach (int i in Loteria)
        {
            Console.Write($"{i} ");
        }
        Console.WriteLine("\n");
    }
}

class Cliente
{
    public int[] Adivinanza { get; set; }

    public Cliente()
    {
        //Adivinanza = new int[5] { -1, -1, -1, -1, -1 };
        //Adivinanza = new int[5] { 0, 1, 2, 3, 4 };
        Adivinanza = new int[5] { 4, 21, 7, 38, 14 };
    }

    public void Adivinar()
    {
        int num;
        bool existe;

        Console.WriteLine("Ingrese los númeres que cree que saldran (0/50):");
        for (int i = 0; i < Adivinanza.Length; i++)
        {
            do
            {
                existe = false;
                if (int.TryParse(Console.ReadLine(), out num) && (num>0 && num<50))
                {
                    foreach (int n in Adivinanza)
                    {
                        if (n == num)
                        {
                            existe = true;
                        }
                    }
                    if (!existe)
                    {
                        Adivinanza[i] = num;
                    }
                    else
                    {
                        Console.WriteLine($"El número {num} ya fue elegido");
                    }
                }
                else
                {
                    Console.WriteLine("Ingresó un caracter inválido");
                    existe = true;
                }
            } while (existe);
        }
    }

    public void mostrar()
    {
        Console.WriteLine("Los números elegidos son:");
        foreach (int i in Adivinanza)
        {
            Console.Write($"{i} ");
        }
        Console.WriteLine("\n");
    }
}