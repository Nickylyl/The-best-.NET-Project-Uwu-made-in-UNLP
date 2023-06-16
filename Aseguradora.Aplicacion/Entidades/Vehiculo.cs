namespace Aseguradora.Aplicacion;

public class Vehiculo
{
    public int ID { get; set; }
    public string? Dominio { get; set; }
    public string? Marca { get; set; }
    public int AnoFabricacion { get; set; }
    public int Titular { get; set; }

    public Vehiculo(string dominio, string marca, int anoFabricacion, int titular)
    {
        Dominio = dominio;
        Marca = marca;
        AnoFabricacion = anoFabricacion;
        Titular = titular;
    }

    public Vehiculo(){

    }

    public override string ToString()
    {
        return  $"{ID}: Dominio:{Dominio} Marca:{Marca} AnoFabricacion:{AnoFabricacion} Titular:{Titular}";
    }
}