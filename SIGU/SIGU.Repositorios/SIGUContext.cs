using Microsoft.EntityFrameworkCore;
using SIGU.Aplicacion.Entidades;
namespace SIGU.Repositorios;

public class SIGUContext : DbContext
{
	#nullable disable
    public DbSet<Usuario> Usuario { get; set; } 
	public DbSet<Reserva> Reserva { get; set; }
	public DbSet<EventoDeportivo> EventoDeportivo { get; set; }
	#nullable restore
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { 
		optionsBuilder.UseSqlite("Data Source=SIGU.sqlite");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}