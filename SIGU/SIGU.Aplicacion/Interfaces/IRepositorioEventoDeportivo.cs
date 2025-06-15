using SIGU.Aplicacion.Entidades;
namespace SIGU.Aplicacion.Interfaces;

public interface IRepositorioEventoDeportivo
{
	List<EventoDeportivo> ObtenerEventosDeportivos();
}