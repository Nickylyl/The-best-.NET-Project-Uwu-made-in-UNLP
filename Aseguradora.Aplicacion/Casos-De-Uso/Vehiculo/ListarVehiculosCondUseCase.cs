namespace Aseguradora.Aplicacion;
public class ListarVehiculosCondUseCase
{
    IRepoVehiculo _repo;
    public ListarVehiculosCondUseCase(IRepoVehiculo repo)
    {
        _repo = repo;
    }
    public List<Vehiculo> Ejecutar(Func<Vehiculo, bool> f)
    {
        return _repo.ListarVehiculosCond(f);
    }
}