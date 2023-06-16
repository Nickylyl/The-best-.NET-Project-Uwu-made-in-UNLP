namespace Aseguradora.Aplicacion;
public class ObtenerVehiculoUseCase
{
    IRepoVehiculo _repo;
    public ObtenerVehiculoUseCase(IRepoVehiculo repo)
    {
        _repo = repo;
    }
    public Vehiculo? Ejecutar(int Id)
    {
        return _repo.ObtenerVehiculo(Id);
    }
}