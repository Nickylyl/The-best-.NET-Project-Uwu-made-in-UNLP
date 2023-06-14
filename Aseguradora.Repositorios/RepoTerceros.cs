namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion;
using Microsoft.EntityFrameworkCore.Sqlite;

public class RepoTerceros : IRepoTercero
{
    public void AgregarTercero(Tercero T)
    {
        // algo
    }
    public void ModificarTercero(Tercero T)
    {
        // algo mas
    }
    public void EliminarTercero(int ID)
    {
        // algo
    }
    public List<Tercero> ListarTerceros()
    {
        //aaaaaaaaaaaaaaaaaa
        return new List<Tercero>();
    }
}