namespace Aseguradora.Repositorios;
using Aseguradora.Aplicacion;
using Microsoft.EntityFrameworkCore;

public class RepoPolizas : IRepoPoliza
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
    public void AgregarPoliza(Poliza p)
    {
        comprobarExistencia();
        if(p.VigenteHasta.CompareTo(p.VigenteDesde)>0)
        {
            if(p.Franquicia!="")
            {
                using (var context = new AseguradoraContext())
                {
                    context.Add(p);
                    context.SaveChanges();
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
            var Pol = context.Polizas.Where(n => n.ID==p.ID).SingleOrDefault();
            if(Pol != null)
            {
                p.ID = Pol.ID;
                context.Remove(Pol);
                context.Add(p);
                context.SaveChanges();
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
            var p = context.Polizas.Where(n => n.ID==ID).SingleOrDefault();
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