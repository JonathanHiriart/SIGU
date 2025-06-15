using SIGU.Aplicacion.Entidades;
namespace SIGU.Aplicacion.Interfaces;

public interface IRepositorioReserva : IRepositorioBase<Reserva>
{
	Reserva? ObtenerPorPersonaYEvento(Guid personaId, Guid eventoId);
	List<Reserva> ObtenerPorEvento(Guid eventoId);
	List<Reserva> ObtenerPorPersona(Guid personaId);
}