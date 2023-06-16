namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion;
using Microsoft.EntityFrameworkCore;

public class RepoVehiculo : IRepoVehiculo
{
    void comprobarExistencia()
    {
        using(var context = new AseguradoraContext())
        {
            if(context.Database.EnsureCreated())
            {
                var connection = context.Database.GetDbConnection();
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "PRAGMA journal_mode=DELETE;";
                    command.ExecuteNonQuery();
                }
            }
        }
    }
    public void AgregarVehiculo(Vehiculo v)
    {
        comprobarExistencia();
        if(v.Marca!="" &&v.Dominio!="" &&v.Titular>0 &&v.AnoFabricacion>0)
        {
            using (var context = new AseguradoraContext())
            {
                context.Add(v);
                context.SaveChanges();
            }
        }else{
            throw new Exception("Informacion de vehiculo invalida, revisar");
        }
    }
    public void ModificarVehiculo(Vehiculo V)
    {
        comprobarExistencia();
        using(var context = new AseguradoraContext())
        {
            Vehiculo? ve = context.Vehiculos.Where(n => n.Dominio==V.Dominio).SingleOrDefault();
            if(ve != null)
            {
                ve.AnoFabricacion = V.AnoFabricacion;
                ve.Dominio = V.Dominio;
                ve.Marca = V.Marca;
                ve.Titular = V.Titular;
                context.SaveChanges();
            }else{
                throw new Exception("No existe el vehículo con Dominio: "+V.Dominio);
            }
        }
    }
    public void EliminarVehiculo(int ID)
    {
        comprobarExistencia();
        using(var context = new AseguradoraContext())
        {
            var v = context.Vehiculos.Where(n => n.ID==ID).SingleOrDefault();
            if(v != null)
            {
                context.Remove(v);
                context.SaveChanges();
            }else{
                throw new Exception("No existe el vehículo con id: "+ID);
            }
        }
    }
    public List<Vehiculo> ListarVehiculos()
    {
        comprobarExistencia();
        List<Vehiculo> listado;
        using(var context = new AseguradoraContext())
        {
            listado = context.Vehiculos.ToList();
        }
        return listado;
    }
    public List<Vehiculo> ListarVehiculosCond(Func<Vehiculo,bool> f)
    {
        comprobarExistencia();
        List<Vehiculo> listado;
        using(var context = new AseguradoraContext())
        {
            listado = context.Vehiculos.Where(f).ToList();
        }
        return listado;
    }
    public Vehiculo? ObtenerVehiculo(int Id)
    {
        comprobarExistencia();
        Vehiculo? v;
        using(var context = new AseguradoraContext())
        {
            v = context.Vehiculos.Where(veh => veh.ID == Id).SingleOrDefault();
        }
        return v;
    }
}