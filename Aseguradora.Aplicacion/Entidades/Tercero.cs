namespace Aseguradora.Aplicacion;

public class Tercero : Persona
{
    public string? Aseguradora { get; set; } 
    public int Siniestro { get; set; }

    public Tercero(int dni, string apellido, string nombre, string aseguradora, int siniestro):base(dni, apellido, nombre)
    {
        this.Aseguradora = aseguradora;
        this.Siniestro = siniestro;
    }

    public Tercero():base(){

    }
}
