using Microsoft.EntityFrameworkCore;

namespace SIGU.Repositorios;

public class DatabaseSqlite
{
    public static void Inicializar()
    {
        using var context = new SIGUContext();

        context.Database.EnsureDeleted(); // Elimina la base de datos si existe, para pruebas

        if (context.Database.EnsureCreated())
        {
            Console.WriteLine("Database created successfully.");
        }

        var connection = context.Database.GetDbConnection();
        connection.Open();

        using var enableFK = connection.CreateCommand();
        enableFK.CommandText = "PRAGMA foreign_keys = ON;";
        enableFK.ExecuteNonQuery();

        using var setJournal = connection.CreateCommand();
        setJournal.CommandText = "PRAGMA journal_mode = DELETE;";
        setJournal.ExecuteNonQuery();

    }
}