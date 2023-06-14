using Microsoft.EntityFrameworkCore;
using Aseguradora.Aplicacion;
namespace Aseguradora.Repositorios;

public class AseguradoraContext : DbContext{
    #nullable
    public DbSet<Poliza> Polizas { get; set; }
    public DbSet<Siniestro> Siniestros { get; set; }
    public DbSet<Tercero> Terceros { get; set; }
    public DbSet<Titular> Titulares { get; set; }
    public DbSet<Vehiculo> Vehiculos { get; set; }
    #nullable

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=Escuela.sqlite");
    }

}