using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SIGU.Aplicacion.Entidades;
using SIGU.Aplicacion.Enums;
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
        // EventoDeportivo → Usuario (Responsable)
        modelBuilder.Entity<EventoDeportivo>()
            .HasOne<Usuario>()
            .WithMany()
            .HasForeignKey(e => e.ResponsbleID)
            .OnDelete(DeleteBehavior.Restrict);

        // Reserva → Usuario
        modelBuilder.Entity<Reserva>()
            .HasOne<Usuario>()
            .WithMany()
            .HasForeignKey(r => r.PersonaId)
            .OnDelete(DeleteBehavior.Restrict);

        // Reserva → EventoDeportivo
        modelBuilder.Entity<Reserva>()
            .HasOne<EventoDeportivo>()
            .WithMany()
            .HasForeignKey(r => r.EventoDeportivoId)
            .OnDelete(DeleteBehavior.Restrict);

        // Usuario.Permisos como string serializado
        var permisosConverter = new ValueConverter<List<Permiso>, string>(
        permisos => string.Join(",", permisos.Select(p => p.ToString())),
        texto => texto.Split(',', StringSplitOptions.RemoveEmptyEntries)
                      .Select(s => Enum.Parse<Permiso>(s))
                      .ToList()
        );

        modelBuilder.Entity<Usuario>()
            .Property(u => u.Permisos)
            .HasConversion(permisosConverter);
    }
}