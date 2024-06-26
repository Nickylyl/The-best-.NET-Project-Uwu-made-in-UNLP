namespace Aseguradora.Aplicacion;
public interface IRepoVehiculo
{
    public void AgregarVehiculo(Vehiculo V);
    public void ModificarVehiculo(Vehiculo V);
    public void EliminarVehiculo(int Id);
    public List<Vehiculo> ListarVehiculos();
    public Vehiculo? ObtenerVehiculo(int Id);
    public List<Vehiculo> ListarVehiculosCond(Func<Vehiculo, bool> f);
}