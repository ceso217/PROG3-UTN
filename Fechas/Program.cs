using System;

/*
ObtenerDiasCalendario() obtiene los días entre dos fechas
b. ObtenerDiasLaborables() obtiene los días laborables entre dos fechas
c. SumarDiasLaborables() obtiene una fecha sumando una cantidad de días a una fecha
inicial
2. Considere fines de semanas y feriados
3. Puede guardar los feriados en un arreglo*/

class Program
{
    static void Main(string[] args)
    {
        Fechas fechas = new Fechas();   
        fechas.ObtenerDiasCalendario();
    }
}

class Fechas
{
    DateTime fecha1 { get; set; }
    DateTime fecha2 { get; set; }

    public void ObtenerDiasCalendario()
    {
        TimeSpan dias = TimeSpan.Zero;
        string fecha;

        Console.WriteLine("Ingrese las fechas de las que quiere obtener los días con el formato dd/mm/aaaa");
        Console.WriteLine("Primer fecha:");
        fecha = Console.ReadLine();
        if(DateTime.TryParse(fecha,out DateTime fecha1))
        {
            Console.WriteLine("Se cargó la primera fecha correctamente");
            Console.WriteLine("Segunda fecha:");
            fecha = Console.ReadLine();
            if(DateTime.TryParse(fecha, out DateTime fecha2))
            {
                Console.WriteLine("Se cargó la segunda fecha correctamente");
                dias = fecha1- fecha2;
                Console.WriteLine(dias);
            }
            else
            {
                Console.WriteLine("No se pudo cargar la segunda fecha correctamente");
            }
        }
        else
        {
            Console.WriteLine("No se pudo cargar la primera fecha correctamente");
        }
    }
}