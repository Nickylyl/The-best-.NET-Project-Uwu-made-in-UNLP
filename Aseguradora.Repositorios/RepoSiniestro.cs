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
            context.Add(S);
            context.SaveChanges();
        }
    }
    public void ModificarSiniestro(Siniestro  S)
    {
        comprobarExistencia();
        using(var context = new AseguradoraContext())
        {
            var sin = context.Siniestros.Where(n => n.ID==S.ID).SingleOrDefault();
            if(sin != null)
            {
                sin.DescripcionDelHecho = S.DescripcionDelHecho;
                sin.DireccionDelHecho = S.DireccionDelHecho;
                sin.FechaCargaSistema = S.FechaCargaSistema;
                sin.FechaOcurrencia = S.FechaOcurrencia;
                sin.Poliza = S.Poliza;
                context.SaveChanges();
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