using Microsoft.EntityFrameworkCore;
using SIGU.Aplicacion.Entidades;
namespace SIGU.Repositorios;

public class SIGUContext : DbContext
{
	public DbSet<Usuario> Usuario { get; set; } = null!;
	public DbSet<Reserva> Reserva { get; set; } = null!;
	public DbSet<EventoDeportivo> EventoDeportivo { get; set; } = null!;
}