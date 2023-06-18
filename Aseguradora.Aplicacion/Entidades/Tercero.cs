namespace Aseguradora.Aplicacion;

public class Tercero : Persona
{
    public string? Aseguradora { get; set; } = "";
    public int SiniestroID { get; set; } // prop navegacion para las tablas segun el modelo

    public Tercero(int dni, string apellido, string nombre, string aseguradora, int siniestro):base(dni, apellido, nombre)
    {
        this.Aseguradora = aseguradora;
        this.SiniestroID = siniestro;
    }

    public Tercero():base(){

    }
}