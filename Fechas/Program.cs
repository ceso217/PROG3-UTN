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

    }
}

class Fechas
{
    DateTime fecha1 { get; set; }
    DateTime fecha2 { get; set; }

    public TimeSpan ObtenerDiasCalendario()
    {
        TimeSpan dias = TimeSpan.Zero;

        Console.WriteLine("Ingrese las fechas de las que quiere obtener los días");
        Console.WriteLine("Primer fecha:");
        fecha1 = 
        return dias;
    }
}