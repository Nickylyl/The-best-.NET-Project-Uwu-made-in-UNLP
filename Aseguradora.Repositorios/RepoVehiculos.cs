namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion;
using Microsoft.EntityFrameworkCore.Sqlite;

public class RepoVehiculo : IRepoVehiculo
{
    public void AgregarVehiculo(Vehiculo v)
    {
        // algo
    }
    public void ModificarVehiculo(Vehiculo v)
    {
        // algo mas
    }
    public void EliminarVehiculo(int ID)
    {
        // algo
    }
    public List<Vehiculo> ListarVehiculos()
    {
        //aaaaaaaaaaaaaaaaaa
        return new List<Vehiculo>();
    }
}