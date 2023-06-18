namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion;
using Microsoft.EntityFrameworkCore;

public class RepoPolizas : IRepoPoliza
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
            if(context.Database.EnsureCreated()) // si la db tuvo que crearse retorna true, sino retorna false
            {
                // config code first dada por la catedra para usar la db en journal mode, es decir, los cambios
                // en la db se reflejan instantaneamente
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
    public void AgregarPoliza(Poliza p)
    {
        comprobarExistencia();
        if(p.VigenteHasta.CompareTo(p.VigenteDesde)>0) // si VigenteHasta es una fecha mayor a VigenteDesde retorna valor mayor a 0
        {
            if(p.Franquicia!="") // comprobamos que la franquicia no sea vacia
            {
                using (var context = new AseguradoraContext())
                {
                    var v = context.Vehiculos.Where(ve => ve.ID == p.VehiculoID).SingleOrDefault(); // buscamos el vehiculo
                    if(v!=null) // si existe agregamos la poliza, caso contrario lanzamos una excepcion
                    {
                        context.Add(p);
                        context.SaveChanges();
                    }else{
                        throw new Exception("El vehiculo asegurado no es valido");
                    }
                }
            }else{
                throw new Exception("No se ingreso una Franquicia");
            }
        }else{
            throw new Exception("La fecha de vencimiento es incorrecta");
        }
    }
    public void ModificarPoliza(Poliza p)
    {
        comprobarExistencia();
        using(var context = new AseguradoraContext())
        {
            var Pol = context.Polizas.Where(n => n.ID==p.ID).SingleOrDefault(); // buscamos la poliza a modificar
            if(Pol != null)
            {
                if(p.VigenteHasta.CompareTo(p.VigenteDesde)>0) // comparamos que las fechas tengan sentido
                {
                    if(p.Franquicia!="") // comprobamos que la franquicia no sea vacia
                    {
                        // actualizamos los datos campo a campo, esto se hace ya que las entidades obtenidas por context
                        // estan conectadas a sus respectivos espacios en las tablas
                        Pol.Cobertura = p.Cobertura;
                        Pol.Franquicia = p.Franquicia;
                        Pol.ValorAsegurado = p.ValorAsegurado;
                        Pol.VehiculoID = p.VehiculoID;
                        Pol.VigenteDesde = p.VigenteDesde;
                        Pol.VigenteHasta = p.VigenteHasta;
                        context.SaveChanges();
                    }else{
                        throw new Exception("No se ingreso una Franquicia");
                    }
                }else{
                    throw new Exception("Las fechas de vigencias no son validas");
                }
            }else{
                throw new Exception("No existe poliza con ID:"+p.ID);
            }
        }
    }
    public void EliminarPoliza(int ID)
    {
        comprobarExistencia();
        using(var context = new AseguradoraContext())
        {
            var p = context.Polizas.Where(n => n.ID==ID).SingleOrDefault(); // buscamos la poliza a eliminar
            if(p != null)
            {
                context.Remove(p);
                context.SaveChanges();
            }else{
                throw new Exception("No existe poliza con ID:" + ID);
            }
        }
    }
    public List<Poliza> ListarPolizas()
    {
        comprobarExistencia();
        List<Poliza> listado;
        using(var context = new AseguradoraContext())
        {
            listado = context.Polizas.ToList();
        }
        return listado;
    }
    public Poliza? ObtenerPoliza(int Id)
    {
        comprobarExistencia();
        Poliza? p;
        using(var context = new AseguradoraContext())
        {
            p = context.Polizas.Where(pol => pol.ID == Id).SingleOrDefault();
        }
        return p;
    }
}