using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SIGU.Aplicacion.Entidades;
using SIGU.Aplicacion.Enums;
namespace SIGU.Repositorios;

public class SIGUContext : DbContext
{
    public SIGUContext(DbContextOptions<SIGUContext> options) : base(options) { }
#nullable disable
    public DbSet<Usuario> Usuario { get; set; } 
	public DbSet<Reserva> Reserva { get; set; }
	public DbSet<EventoDeportivo> EventoDeportivo { get; set; }
	#nullable restore
	//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { 
	//	optionsBuilder.UseSqlite("Data Source=SIGU.sqlite");
 //   }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Usuario → Reservas (1:N)
        modelBuilder.Entity<Reserva>()
            .HasOne(r => r.Usuario)
            .WithMany(p => p.Reservas)
            .HasForeignKey(r => r.usuarioID)
            .OnDelete(DeleteBehavior.Restrict);

        // EventoDeportivo → Reservas (1:N)
        modelBuilder.Entity<Reserva>()
            .HasOne(r => r.EventoDeportivo)
            .WithMany(e => e.Reservas)
            .HasForeignKey(r => r.EventoDeportivoId)
            .OnDelete(DeleteBehavior.Restrict);

        // Usuario → EventoDeportivo (Responsable) (1:N)
        modelBuilder.Entity<EventoDeportivo>()
            .HasOne(e => e.Responsable)
            .WithMany(p => p.EventosResponsables)
            .HasForeignKey(e => e.ResponsbleID)
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