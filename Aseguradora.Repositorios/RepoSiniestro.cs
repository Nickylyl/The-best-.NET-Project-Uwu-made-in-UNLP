namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion;
using Microsoft.EntityFrameworkCore;

public class RepoSiniestro : IRepoSiniestro 
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
    public void AgregarSiniestro(Siniestro  S)
    {
        comprobarExistencia();
        using(var context = new AseguradoraContext())
        {
            var pol = context.Polizas.Where( p => S.Poliza == p.ID).SingleOrDefault();
            if(pol!=null)
            {
                S.FechaCargaSistema = DateTime.Now;
                if(pol.VigenteHasta.CompareTo(S.FechaCargaSistema)>0)
                {
                    context.Add(S);
                    context.SaveChanges();
                }else{
                    throw new Exception("La poliza está vencida");
                }
            }else{
                throw new Exception("No existe la poliza asociada");
            }
        }
    }
    public void ModificarSiniestro(Siniestro  S)
    {
        comprobarExistencia();
        using(var context = new AseguradoraContext())
        {
            // comprobamos que existe el siniestro
            var sin = context.Siniestros.Where(n => n.ID==S.ID).SingleOrDefault();
            if(sin != null)
            {
                // comprobamos que existe la poliza
                var pol = context.Polizas.Where(n=> sin.Poliza == n.ID).SingleOrDefault();
                if(pol!=null)
                {
                    sin.DescripcionDelHecho = S.DescripcionDelHecho;
                    sin.DireccionDelHecho = S.DireccionDelHecho;
                    sin.FechaOcurrencia = S.FechaOcurrencia;
                    sin.Poliza = S.Poliza;
                    context.SaveChanges();
                }else{
                    throw new Exception("Poliza Invalida ");
                }                
            }else{
                throw new Exception("No existe Siniestro con ID: "+S.ID);
            }
        }
    }
    public void EliminarSiniestro(int ID)
    {
        comprobarExistencia();
        using(var context = new AseguradoraContext())
        {
            var p = context.Siniestros.Where(n => n.ID==ID).SingleOrDefault();
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