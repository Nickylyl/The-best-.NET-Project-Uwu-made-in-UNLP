namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion;
using Microsoft.EntityFrameworkCore;

public class RepoTitulares : IRepoTitular{
    
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

    public void AgregarTitular(Titular T)
    {
        comprobarExistencia();
        using(var context = new AseguradoraContext()){
            var t = context.Titulares.Where(tit=> tit.DNI == T.DNI).SingleOrDefault();
            if( t == null){
                if(T.DNI>0 && T.Nombre!="" && T.Apellido!="")
                {
                    context.Add(T);
                    context.SaveChanges();
                }else{
                    throw new Exception("Los campos DNI, Nombre y Apellido son obligatorios");
                }
            }
            else{
                throw new Exception("El Titular ya existe");
            }
        }
    }

    public void ModificarTitular(Titular T)
    {
        comprobarExistencia();
        using(var context = new AseguradoraContext()){ 
            // busca la id del titular para modificarlo
            Titular? tit = context.Titulares.Where(tit => tit.ID == T.ID).SingleOrDefault(); 
            if( tit != null){
                // comprueba si el dni no está usado antes de actualizar el titular de dicha id
                var t2 = context.Titulares.Where(tit => tit.DNI == T.DNI).SingleOrDefault();
                if(t2==null || t2.ID==tit.ID)
                {
                    // actualizamos los datos campo a campo, esto se hace ya que las entidades obtenidas por context
                    // estan conectadas a sus respectivos espacios en las tablas
                    tit.DNI = T.DNI;
                    tit.Apellido = T.Apellido;
                    tit.Direccion = T.Direccion;
                    tit.Email = T.Email;
                    tit.Nombre = T.Nombre;
                    tit.Telefono = T.Telefono;
                    context.SaveChanges();
                }else{
                    throw new Exception("El dni ingresado no es valido.");
                }
            }
            else{
                throw new Exception("El Titular ingresado a modificar no es valido.");
            }
        }
    }
    public void EliminarTitular(int ID)
    {
        comprobarExistencia();
        using(var context = new AseguradoraContext()){
            var t = context.Titulares.Where(tit => tit.ID == ID).SingleOrDefault();
            if( t != null ){
                context.Remove(t);
                context.SaveChanges();
            }
            else{
                throw new Exception("El Titular con ID = {0} ingresado a eliminar no existe." + ID);
            }
        }
    }
    public List<Titular> ListarTitulares()
    {
        List<Titular> listita = new List<Titular>();
        comprobarExistencia();
        using(var context = new AseguradoraContext()){
            listita = context.Titulares.ToList();
        }
        return listita;
    }
    public Titular? ObtenerTitular(int Id)
    {
        Titular? t;
        using(var context = new AseguradoraContext())
        {
            t = context.Titulares.Where(tit => tit.ID == Id).SingleOrDefault();
        }
        return t;
    }
}