namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion;
using Microsoft.EntityFrameworkCore.Sqlite;

public class RepoSiniestro : IRepoSiniestro 
{
    public void AgregarSiniestro(Siniestro  S)
    {
        // algo
    }
    public void ModificarSiniestro(Siniestro  S)
    {
        // algo mas
    }
    public void EliminarSiniestro(int ID)
    {
        // algo
    }
    public List<Siniestro> ListarSiniestros()
    {
        //aaaaaaaaaaaaaaaaaa
        return new List<Siniestro>();
    }
}