using SIGU.Aplicacion.Entidades;
using SIGU.Aplicacion.Enums;
using SIGU.Aplicacion.Excepciones;
using SIGU.Aplicacion.Interfaces;
namespace SIGU.Aplicacion.CasoDeUso;
public class EventoDeportivoListadoUseCase
{
    private readonly IServicioAutorizacion _servicioAutorizacion;
    private readonly IRepositorioEventoDeportivo _repositorioEventoDeportivo;

    public EventoDeportivoListadoUseCase(IServicioAutorizacion servicioAutorizacion,IRepositorioEventoDeportivo repositorioEventoDeportivo)
    {
        _servicioAutorizacion = servicioAutorizacion;
        _repositorioEventoDeportivo = repositorioEventoDeportivo;
    }
    public async Task<List<EventoDeportivo>> EjecutarAsync(Guid idUsuario)
    {
        var estaAutorizado = await _servicioAutorizacion.EstaAutorizado(idUsuario, Permiso.EventoListar);
        if (!estaAutorizado)
        {
            throw new FalloAutorizacionException("El usuario no tiene permiso para listar Eventos deportivos.");
        }
        List<EventoDeportivo> ListaEventos = await _repositorioEventoDeportivo.ListarAsync() ?? new List<EventoDeportivo>();
        if (ListaEventos.Count == 0)
        {
            throw new ValidacionException("No se encontraron eventos deportivos.");
        }
        List<EventoDeportivo> listaEventosFiltrada = new List<EventoDeportivo>();
        foreach (var evento in ListaEventos)
        {
            if (evento.FechaHoraInicio > DateTime.Now)
            {
                listaEventosFiltrada.Add(evento);
            }
        }
        return listaEventosFiltrada;
    }
}
