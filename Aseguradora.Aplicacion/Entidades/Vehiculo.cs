namespace Aseguradora.Aplicacion;

public class Vehiculo
{
    public int ID { get; set; }
    public string? Dominio { get; set; }
    public string? Marca { get; set; }
    public int AnoFabricacion { get; set; }
    public int TitularID { get; set; } // prop navegacion para las tablas segun el modelo
    public List<Poliza>? Polizas {get;set;} // prop navegacion para las tablas segun el modelo

    public Vehiculo(string dominio, string marca, int anoFabricacion, int titular)
    {
        Dominio = dominio;
        Marca = marca;
        AnoFabricacion = anoFabricacion;
        TitularID = titular;
    }

    public Vehiculo(){

    }

    public override string ToString()
    {
        return  $"{ID}: Dominio:{Dominio} Marca:{Marca} AnoFabricacion:{AnoFabricacion} Titular:{TitularID}";
    }
}