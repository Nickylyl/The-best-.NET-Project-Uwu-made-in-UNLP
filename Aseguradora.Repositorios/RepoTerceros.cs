namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion;
using Microsoft.EntityFrameworkCore;

public class RepoTerceros : IRepoTercero
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
    public void AgregarTercero(Tercero T)
    {
        comprobarExistencia();
        using(var context = new AseguradoraContext()){
            var t = context.Terceros.Where(ter=> ter.DNI == T.DNI).SingleOrDefault();
            if( t == null){
                context.Add(T);
                context.SaveChanges();
            }
            else{
                throw new Exception("El Tercero = {0} ya existe, no se pudo agregar." + T.ToString());
            }
        }
    }
    public void ModificarTercero(Tercero T)
    {
        comprobarExistencia();
        using(var context = new AseguradoraContext()){
            var t = context.Terceros.Where(ter => ter.DNI == T.DNI).SingleOrDefault();
            if( t != null){
                t = T;
                context.SaveChanges();
            }
            else{
                throw new Exception("El Tercero = {0} ingresado a modificar no existe." + T.ToString());
            }
        }
    }
    public void EliminarTercero(int ID)
    {
        comprobarExistencia();
        using(var context = new AseguradoraContext()){
            var t = context.Terceros.Where(tit => tit.ID == ID).SingleOrDefault();
            if( t != null ){
                context.Remove(t);
                context.SaveChanges();
            } 
            else{
                throw new Exception("El Eliminar con ID = {0} ingresado a eliminar no existe." + ID);
            }
        }
    }
    
    public List<Tercero> ListarTerceros()
    {
        List<Tercero> listita = new List<Tercero>();
        comprobarExistencia();
        using(var context = new AseguradoraContext()){
            listita = context.Terceros.ToList();
        }
        return listita;
    }
}