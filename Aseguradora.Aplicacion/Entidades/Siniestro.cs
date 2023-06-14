namespace Aseguradora.Aplicacion;

public class Siniestro
{
    public int ID {get;set;} = -1;
    public int Poliza {get;set;}
    public DateTime FechaCargaSistema {get;set;}
    public DateTime FechaOcurrencia {get;set;}
    public string? DireccionDelHecho {get;set;} 
    public string? DescripcionDelHecho {get;set;} 

    public Siniestro(int id, int poliza, DateTime fechaOcurrencia, string direccionDelHecho, string descripcionDelHecho){
        this.ID = id;
        this.Poliza = poliza;
        this.FechaCargaSistema = DateTime.Now;
        this.FechaOcurrencia = fechaOcurrencia;
        this.DescripcionDelHecho = descripcionDelHecho;
        this.DireccionDelHecho = direccionDelHecho;
    }

    public Siniestro(){

    }
}