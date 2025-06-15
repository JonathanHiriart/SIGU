using SIGU.Aplicacion.Entidades;
namespace SIGU.Aplicacion.Interfaces;

public interface IRepositorioEventoDeportivo : IRepositorioBase<EventoDeportivo>
{
    List<EventoDeportivo> ObtenerPorPersona(Guid personaId);
}