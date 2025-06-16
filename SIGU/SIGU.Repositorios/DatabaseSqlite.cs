namespace SIGU.Repositorios;

public class DatabaseSqlite
{
    public static void Inicializar()
    {
        using var context = new SIGUContext();
        if (context.Database.EnsureCreated())
        {
            Console.WriteLine("Database created successfully.");
        }
        else
        {
            Console.WriteLine("Database already exists.");
        }
    }
}