namespace Aseguradora.Repositorios;
using Microsoft.EntityFrameworkCore;

public class CrearDB{
    public static void Ejecutar()
    {
        /*
            Comprobar existencia sirve para que si en runtime se elimina el archivo .sqlite
            podamos recuperarlo sin necesidad de reiniciar todo el programa y a su vez sirve
            de proteccion contra errores en tiempo de ejecucion o excepciones por falta de db
        */
        using (var context = new AseguradoraContext())
        {
            if (context.Database.EnsureCreated()) // si la db tuvo que crearse retorna true, sino retorna false
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
}