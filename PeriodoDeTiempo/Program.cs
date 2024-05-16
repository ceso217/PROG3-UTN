using System;

class Program
{
    static void Main(string[] args)
    {
        LineaDeTiempo lineaDeTiempo = new LineaDeTiempo();

        lineaDeTiempo.mostrar();
        lineaDeTiempo.union();
        lineaDeTiempo.mostrar();
    }
}

class LineaDeTiempo
{
    private Periodo[] periodos { get; set; }

    public LineaDeTiempo()
    {
        this.periodos = new Periodo[] {
            new Periodo(DateTime.Parse("04/05/2024 14:30:00"), DateTime.Parse("17/05/2024 17:25:00"), "A") ,
            new Periodo(DateTime.Parse("12/05/2024 11:15:00"), DateTime.Parse("25/05/2024 7:10:00"), "B") ,
            new Periodo(DateTime.Parse("08/05/2024 21:50:00"), DateTime.Parse("10/05/2024 3:00:00"),"C") ,
            new Periodo(DateTime.Parse("27/05/2024 23:35:00"), DateTime.Parse("30/05/2024 20:55:00"),"D")
        };
    }

    // lo hice para agregar en el main los periodos pero al final decidi agregar los objetos en el constructor por defecto para ahorrar tiempo
    public void agregarPeriodo(Periodo p)
    {
        for (int i = 0; i < periodos.Length; i++)
        {
            if (periodos[i] == null)
            {
                periodos[i] = p;
                break;
            }
        }
    }

    public void union()
    {
        bool huboUnion;
        do
        {
            huboUnion = false;
            int indice = 0;
            //recorre el arreglo de periodos
            foreach (Periodo p1 in periodos)
            {
                if (p1 is not null)
                {
                    //crea una copia de la fecha de inicio de un periodo y asi usarla para recorrer todo el periodo
                    DateTime fechaAux = p1.FechaInicio;
                    // recorre el periodo al incrementar los dias en cada bucle hasta llegar a su fecha de fin
                    while (fechaAux.Date < p1.FechaFin.Date)
                    {
                        //recorre el arreglo de periodos nuevamente
                        foreach (Periodo p2 in periodos)
                        {
                            if (p2 is not null)
                            {
                                // compara si la fecha que esta recorriendo el periodo coincide con la fecha inicial de alguno de los otros periodos, y tiene en cuenta que no sea del mismo periodo al comparar sus posiciones en el arreglo
                                if (fechaAux.Date == p2.FechaInicio.Date && Array.IndexOf(periodos, p1) != Array.IndexOf(periodos, p2))
                                {
                                    Console.WriteLine($"Se unieron efectivamente los periodos {p1.Nombre} y {p2.Nombre}");
                                    //cambia el nombre de p1 por el nombre de la nueva union
                                    p1.Nombre = p1.Nombre + p2.Nombre;
                                    // si la fecha de fin de p2 es despues que la de p1 asigna esa como la nueva fecha fin de la union de los periodos
                                    if (p1.FechaFin < p2.FechaFin)
                                    {
                                        p1.FechaFin = p2.FechaFin;
                                    }
                                    //guarda el indice de p2 para luego limpiarlo
                                    indice = Array.IndexOf(periodos, p2);
                                    //vuelve true huboUnion para salir de todos los bucles y asi repetir el proceso hasta que no queden más periodos solapados
                                    huboUnion = true;
                                    break;
                                }
                            }
                        }
                        fechaAux = fechaAux.AddDays(1);
                        if (huboUnion) break;
                    }
                }
                if (huboUnion) break;
            }
            if (huboUnion)
            {
                periodos[indice] = null;
            }
        } while (huboUnion);
        Console.WriteLine("\n");
    }

    public void mostrar()
    {
        foreach (Periodo p in periodos)
        {
            if (p is not null)
            {
                Console.WriteLine($"El periodo {p.Nombre} va desde la fecha {p.FechaInicio} hasta {p.FechaFin}");
            }
        }
        Console.WriteLine("\n");
    }
}

class Periodo
{
    public string Nombre { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }

    public Periodo(DateTime FechaInicio, DateTime FechaFin, string Nombre)
    {
        this.Nombre = Nombre;
        this.FechaInicio = FechaInicio;
        this.FechaFin = FechaFin;
    }
}