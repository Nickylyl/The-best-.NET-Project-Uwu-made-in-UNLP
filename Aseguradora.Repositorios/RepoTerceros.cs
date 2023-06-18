namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion;
using Microsoft.EntityFrameworkCore;

public class RepoTerceros : IRepoTercero
{
    void comprobarExistencia()
    {
        /*
            Comprobar existencia sirve para que si en runtime se elimina el archivo .sqlite
            podamos recuperarlo sin necesidad de reiniciar todo el programa y a su vez sirve
            de proteccion contra errores en tiempo de ejecucion o excepciones por falta de db
        */
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
            // comprobamos que exista el siniestro
            var sin = context.Siniestros.Where(sins => sins.ID == T.SiniestroID).SingleOrDefault();
            if(sin!=null)
            {
                // comprobamos que los datos no sean vacios o por defecto
                if(T.DNI > 0 && T.SiniestroID > 0 && T.Nombre != "" && T.Apellido != "" && T.Aseguradora != "" && T.Telefono != "")
                {
                    context.Add(T);
                    context.SaveChanges();
                }else{
                    throw new Exception("Algunos campos son invalidos");
                }
            }else{
                throw new Exception("El siniestro no existe");
            }
        }
    }
    public void ModificarTercero(Tercero T)
    {
        comprobarExistencia();
        using(var context = new AseguradoraContext()){
            // buscamos el tercero
            var ter = context.Terceros.Where(ters => ters.ID == T.ID).SingleOrDefault();
            if( ter != null){
                // comprobamos si el siniestro es valido
                var sin = context.Siniestros.Where(sins => sins.ID == T.SiniestroID).SingleOrDefault();
                if(sin != null){
                    // actualizamos los datos campo a campo, esto se hace ya que las entidades obtenidas por context
                    // estan conectadas a sus respectivos espacios en las tablas
                    ter.Apellido = T.Apellido;
                    ter.Aseguradora = T.Aseguradora;
                    ter.DNI = T.DNI;
                    ter.Nombre = T.Nombre;
                    ter.SiniestroID = T.SiniestroID;
                    ter.Telefono = T.Telefono;
                    context.SaveChanges();
                }else{
                    throw new Exception("No existe el siniestro");
                }
            }
            else{
                throw new Exception("El Tercero a modificar no existe.");
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
            listita = context.Terceros.OrderBy(t => t.DNI).ToList();
        }
        return listita;
    }
    public Tercero? ObtenerTercero(int Id)
    {
        Tercero? t;
        using(var context = new AseguradoraContext())
        {
            t = context.Terceros.Where(ter => ter.ID == Id).SingleOrDefault();
        }
        return t;
    }
}