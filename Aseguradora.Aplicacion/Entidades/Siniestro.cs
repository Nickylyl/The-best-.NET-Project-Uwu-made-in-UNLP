namespace Aseguradora.Aplicacion;

public class Siniestro
{
    public int ID {get;set;}
    public DateTime FechaCargaSistema {get;set;}
    public DateTime FechaOcurrencia {get;set;}
    public string? DireccionDelHecho {get;set;} 
    public string? DescripcionDelHecho {get;set;}
    public int PolizaID { get; set; } // prop navegacion para las tablas segun el modelo
    public List<Tercero>? Terceros {get;set;} // prop navegacion para las tablas segun el modelo

    public Siniestro(int id, int poliza, DateTime fechaOcurrencia, string direccionDelHecho, string descripcionDelHecho){
        this.ID = id;
        this.PolizaID = poliza;
        this.FechaCargaSistema = DateTime.Now;
        this.FechaOcurrencia = fechaOcurrencia;
        this.DescripcionDelHecho = descripcionDelHecho;
        this.DireccionDelHecho = direccionDelHecho;
    }

    public Siniestro(){

    }
}