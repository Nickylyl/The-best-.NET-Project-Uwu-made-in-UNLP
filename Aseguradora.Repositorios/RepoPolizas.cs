namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion;
using Microsoft.EntityFrameworkCore.Sqlite;

public class RepoPolizas : IRepoPoliza
{
    public void AgregarPoliza(Poliza p)
    {
        // algo
    }
    public void ModificarPoliza(Poliza p)
    {
        // algo mas
    }
    public void EliminarPoliza(int ID)
    {
        // algo
    }
    public List<Poliza> ListarPolizas()
    {
        //aaaaaaaaaaaaaaaaaa
        return new List<Poliza>();
    }
}