using System;

class Program
{
    static void Main(string[] args)
    {
        
    }
}

class Banco
{
    List <CuentaBancaria> Cuentas { get; set; }

    public Banco()
    {
        this.Cuentas = new List<CuentaBancaria>() { new CuentaAhorro(), new CuentaAhorro(), new CuentaAhorro(), new CuentaAhorro(), new CuentaAhorro(), new CuentaCorriente(), new CuentaCorriente(), new CuentaCorriente(), new CuentaCorriente(), new CuentaCorriente() };
    }
}
class CuentaBancaria
{
    public float Saldo { get; set; }

    public void deposito(float dinero)
    {
        Saldo += dinero;
    }

    public virtual void extraccion(float dinero)
    {
        if(dinero <= Saldo)
        {
            Saldo -= dinero;
            Console.WriteLine("Se hizo la extracción correctamente");
        }
        else
        {
            Console.WriteLine("No tiene esa cantidad de dinero para extraer");
        }
    }
}

class CuentaAhorro : CuentaBancaria
{

}
class CuentaCorriente : CuentaBancaria
{
    public float Descubierto { get; set; }

    public CuentaCorriente()
    {
        this.Descubierto = 150;
    }
    public override void extraccion(float dinero)
    {
        if(dinero <= Saldo)
        {
            base.extraccion(dinero);
        }
        else if (dinero <= Descubierto && ) { }
        {

        }
    }
}