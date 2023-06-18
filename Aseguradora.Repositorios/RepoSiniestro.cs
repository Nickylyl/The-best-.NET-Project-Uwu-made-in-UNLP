namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion;
using Microsoft.EntityFrameworkCore;

public class RepoSiniestro : IRepoSiniestro 
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
    public void AgregarSiniestro(Siniestro  S)
    {
        comprobarExistencia();
        if (S.FechaOcurrencia.CompareTo(DateTime.Now) <= 0)
        {
            using (var context = new AseguradoraContext())
            {
                var pol = context.Polizas.Where(p => S.PolizaID == p.ID).SingleOrDefault();
                if (pol != null)
                {
                    S.FechaCargaSistema = DateTime.Now;
                    // si el vencimiento es despues de la fecha de carga y la vigencia arrancó antes de la ocurrencia ta todo bien y se carga
                    if (pol.VigenteHasta.CompareTo(S.FechaCargaSistema) > 0 && pol.VigenteDesde.CompareTo(S.FechaOcurrencia) < 0)  // comparamos que las fechas tengan sentido
                    {                                                       // es decir, si vencimiento es mayor que la fecha de carga
                    context.Add(S);
                    context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("La poliza no es valida");
                    }
                }
                else
                {
                    throw new Exception("No existe la poliza asociada");
                }
            }
        }else{
            throw new Exception("La fecha de ocurrencia no puede ser en el futuro");
        }
        
    }
    public void ModificarSiniestro(Siniestro  S)
    {
        comprobarExistencia();
        if(S.FechaOcurrencia.CompareTo(DateTime.Now)<=0)
        {
            using (var context = new AseguradoraContext())
            {
                // comprobamos que existe el siniestro
                var sin = context.Siniestros.Where(n => n.ID == S.ID).SingleOrDefault();
                if (sin != null)
                {
                    // comprobamos que existe la poliza
                    var pol = context.Polizas.Where(n => sin.PolizaID == n.ID).SingleOrDefault();
                    if (pol != null)
                    {// si el vencimiento es despues de la fecha de carga y la vigencia arrancó antes de la ocurrencia ta todo bien y se actualiza
                        if(pol.VigenteHasta.CompareTo(sin.FechaCargaSistema)>0 && pol.VigenteDesde.CompareTo(sin.FechaOcurrencia)<0) 
                        // actualizamos los datos campo a campo, esto se hace ya que las entidades obtenidas por context
                        // estan conectadas a sus respectivos espacios en las tablas
                        sin.DescripcionDelHecho = S.DescripcionDelHecho;
                        sin.DireccionDelHecho = S.DireccionDelHecho;
                        sin.FechaOcurrencia = S.FechaOcurrencia;
                        sin.PolizaID = S.PolizaID;
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Poliza Invalida ");
                    }
                }
                else
                {
                    throw new Exception("No existe Siniestro con ID: " + S.ID);
                }
            }
        }else{
            throw new Exception("La fecha de ocurrencia no puede ser en el futuro");
        }
    }
    public void EliminarSiniestro(int ID)
    {
        comprobarExistencia();
        using(var context = new AseguradoraContext())
        {
            var p = context.Siniestros.Where(n => n.ID==ID).SingleOrDefault(); // buscamos el siniestro a eliminar
            if(p != null)
            {
                context.Remove(p);
                context.SaveChanges();
            }else{
                throw new Exception("No existe Siniestro con ID: "+ID);
            }
        }
    }
    public List<Siniestro> ListarSiniestros()
    {
        comprobarExistencia();
        List<Siniestro> listado;
        using(var context = new AseguradoraContext())
        {
            listado = context.Siniestros.ToList();
        }
        return listado;
    }
    public Siniestro? ObtenerSiniestro(int Id)
    {
        Siniestro? s;
        using(var context = new AseguradoraContext())
        {
            s = context.Siniestros.Where(sin => sin.ID == Id).SingleOrDefault();
        }
        return s;
    }
}