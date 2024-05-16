using System;

/*
ObtenerDiasCalendario() obtiene los días entre dos fechas
ObtenerDiasLaborables() obtiene los días laborables entre dos fechas
SumarDiasLaborables() obtiene una fecha sumando una cantidad de días a una fecha inicial
Considere fines de semanas y feriados
Puede guardar los feriados en un arreglo
*/

class Program
{
    static void Main(string[] args)
    {
        // Crear una instancia de la clase Fechas y llamar a sus métodos
        Fechas fechas = new Fechas();
        fechas.ObtenerDiasCalendario();    // Obtener la cantidad de días entre dos fechas
        fechas.ObtenerDiasLaborales();     // Obtener la cantidad de días laborales entre dos fechas
        fechas.SumarDiasLaborales();       // Sumar una cantidad de días laborales a una fecha
    }
}

class Fechas
{
    // Arreglo de fechas feriadas
    DateTime[] feriados = { DateTime.Parse("09/05/2024"), DateTime.Parse("14/05/2024") };

    // Método para ingresar dos fechas
    public bool Entrada(ref DateTime fecha1, ref DateTime fecha2)
    {
        string fecha;

        // Solicitar al usuario la primera fecha
        Console.WriteLine("Ingrese las fechas de las que quiere obtener los días con el formato dd/MM/yyyy");
        Console.WriteLine("Primer fecha:");
        // fecha = Console.ReadLine();
        fecha = "07/05/2024";  // Se usa una fecha hardcoded para pruebas, descomentar la linea superior para la implementación real
        if (DateTime.TryParse(fecha, out fecha1))
        {
            Console.WriteLine("Se cargó la primera fecha correctamente");
            // Solicitar al usuario la segunda fecha
            Console.WriteLine("Segunda fecha:");
            // fecha = Console.ReadLine();
            fecha = "14/05/2024";  // Se usa una fecha hardcoded para pruebas, descomentar la linea superior para la implementación real
            if (DateTime.TryParse(fecha, out fecha2))
            {
                Console.WriteLine("Se cargó la segunda fecha correctamente");
                return true;
            }
            else
            {
                Console.WriteLine("No se pudo cargar la segunda fecha correctamente");
                return false;
            }
        }
        else
        {
            Console.WriteLine("No se pudo cargar la primera fecha correctamente");
            return false;
        }
    }

    // Sobrecarga del método Entrada para ingresar una sola fecha
    public bool Entrada(ref DateTime fecha1)
    {
        string fecha;

        // Solicitar al usuario la fecha
        Console.WriteLine("Ingrese la fecha a la que quiere sumar los días con el formato dd/MM/yyyy");
        Console.WriteLine("Fecha:");
        // fecha = Console.ReadLine();
        fecha = "07/05/2024";  // Se usa una fecha hardcoded para pruebas, descomentar la linea superior para la implementación real
        if (DateTime.TryParse(fecha, out fecha1))
        {
            Console.WriteLine("Se cargó la fecha correctamente");
            return true;
        }
        else
        {
            Console.WriteLine("No se pudo cargar la fecha correctamente");
            return false;
        }
    }

    // Método para obtener la cantidad de días entre dos fechas
    public void ObtenerDiasCalendario()
    {
        DateTime fecha1 = new DateTime();
        DateTime fecha2 = new DateTime();
        TimeSpan dias = TimeSpan.Zero;

        if (Entrada(ref fecha1, ref fecha2))
        {
            // Calcular la diferencia en días entre las dos fechas
            dias = fecha1 < fecha2 ? (fecha2 - fecha1) : (fecha1 - fecha2);
            Console.WriteLine($"Entre las dos fechas hay {dias.Days} días\n");
        }
    }

    // Método para obtener la cantidad de días laborales entre dos fechas
    public void ObtenerDiasLaborales()
    {
        DateTime fecha1 = new DateTime();
        DateTime fecha2 = new DateTime();
        int diasLab;

        if (Entrada(ref fecha1, ref fecha2))
        {
            // Calcular la diferencia en días entre las dos fechas
            TimeSpan dias = fecha1 < fecha2 ? (fecha2 - fecha1) : (fecha1 - fecha2);
            diasLab = dias.Days;

            // Recorre cada día entre las dos fechas y descuenta los fines de semana y feriados, es decir los días no laborales
            while (fecha1 <= fecha2)
            {
                if (fecha1.DayOfWeek == DayOfWeek.Sunday || fecha1.DayOfWeek == DayOfWeek.Saturday || esFeriado(fecha1))
                {
                    diasLab--;
                }
                fecha1 = fecha1.AddDays(1);
            }
            Console.WriteLine($"Entre las dos fechas hay {diasLab} días laborales\n");
        }
    }

    // Método para sumar días laborales a una fecha
    public void SumarDiasLaborales()
    {
        DateTime fecha = new DateTime();
        DateTime fecha1 = new DateTime();
        int diasLab;
        int copyDays;

        if (Entrada(ref fecha))
        {
            fecha1 = fecha;
            Console.WriteLine("Ingrese la cantidad de días laborales que quiere agregar:");
            diasLab = Convert.ToInt32(Console.ReadLine());
            copyDays = diasLab;

            while (diasLab != 0)
            {
                fecha1 = fecha1.AddDays(1);

                // Si no es fin de semana ni feriado, reduce el contador de los días laborales que tiene que sumar
                if (fecha1.DayOfWeek != DayOfWeek.Sunday && fecha1.DayOfWeek != DayOfWeek.Saturday && !esFeriado(fecha1))
                {
                    diasLab--;
                }
            }

            Console.WriteLine($"La fecha del {fecha.ToShortDateString()} más {copyDays} días laborales cae en la fecha {fecha1.ToShortDateString()}");
        }
    }

    // Método que verifica si una fecha es feriado
    public bool esFeriado(DateTime fecha)
    {
        for (int i = 0; i < feriados.Length; i++)
        {
            if (feriados[i] == fecha)
            {
                return true;
            }
        }
        return false;
    }
}
