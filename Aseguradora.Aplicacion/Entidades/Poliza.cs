namespace Aseguradora.Aplicacion;

public class Poliza
{
    public int ID { get; set; }
    public double ValorAsegurado { get; set; }
    public string? Franquicia { get; set; }
    public string? Cobertura { get; set; }
    public DateTime VigenteDesde { get; set; }
    public DateTime VigenteHasta { get; set; }
    public int VehiculoID { get; set; } // prop navegacion para las tablas segun el modelo
    public List<Siniestro>? Siniestros {get;set;} // prop navegacion para las tablas segun el modelo
    public Poliza(int vehiculoAsegurado, double valorAsegurado, string franquicia, string cobertura, DateTime vigenteDesde, DateTime vigenteHasta)
    {
        VehiculoID = vehiculoAsegurado;
        ValorAsegurado = valorAsegurado;
        Franquicia = franquicia;
        Cobertura = cobertura;
        VigenteDesde = vigenteDesde;
        VigenteHasta = vigenteHasta;
    }

    public Poliza(){

    }

    public override string ToString()
    {
        return  $"{ID}: VehiculoAsegurado:{VehiculoID} ValorAsegurado:{ValorAsegurado}"+
                $" Franquicia:{Franquicia} Cobertura:{Cobertura} VigenteDesde:{VigenteDesde:d}"+
                $" VigenteHasta:{VigenteHasta:MM/dd/yyyy}";
    }
}
