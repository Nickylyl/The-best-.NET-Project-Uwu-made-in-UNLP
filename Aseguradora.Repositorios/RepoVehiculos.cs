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
        using(var context = new AseguradoraContext())
        {
            context.Add(v);
            context.SaveChanges();
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
                V.ID = ve.ID;
                context.Update(V);
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
}