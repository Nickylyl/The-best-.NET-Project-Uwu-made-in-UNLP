namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion;
using Microsoft.EntityFrameworkCore.Sqlite;

public class RepoTitulares : IRepoTitular
{
    public void AgregarTitular(Titular T)
    {
        // algo
    }
    public void ModificarTitular(Titular T)
    {
        // algo mas
    }
    public void EliminarTitular(int ID)
    {
        // algo
    }
    public List<Titular> ListarTitulares()
    {
        //aaaaaaaaaaaaaaaaaa
        return new List<Titular>();
    }
}