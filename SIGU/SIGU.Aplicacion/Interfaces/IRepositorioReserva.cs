using SIGU.Aplicacion.Entidades;
namespace SIGU.Aplicacion.Interfaces;

public interface IRepositorioReserva : IRepositorioBase<Reserva>
{
	Reserva? ObtenerPorPersonaYEvento(int personaId, int eventoId);
	List<Reserva> ObtenerPorEvento(int eventoId);
	List<Reserva> ObtenerPorPersona(int personaId);
}