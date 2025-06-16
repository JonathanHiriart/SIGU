using SIGU.Aplicacion.DTOs;
using SIGU.Aplicacion.Entidades;
using SIGU.Aplicacion.Enums;
using SIGU.Aplicacion.Excepciones;
using SIGU.Aplicacion.Interfaces;
using SIGU.Aplicacion.Validadores;
namespace SIGU.Aplicacion.CasoDeUso;
public class EventoDeportivoBajaUseCase
{
    private readonly IRepositorioEventoDeportivo _repositorioEventoDeportivo;
    private readonly IRepositorioReserva _repositorioReserva;
    private readonly IServicioAutorizacion _servicioAutorizacion;
    private readonly ValidadorEventoDeportivo _validadorEventoDeportivo;

    public EventoDeportivoBajaUseCase(IRepositorioEventoDeportivo repositorioEventoDeportivo, IServicioAutorizacion servicioAutorizacion,IRepositorioReserva repositorioReserva, ValidadorEventoDeportivo validadorEventoDeportivo)
    {
        _repositorioEventoDeportivo = repositorioEventoDeportivo;
        _servicioAutorizacion = servicioAutorizacion;
        _repositorioReserva = repositorioReserva;
        _validadorEventoDeportivo = validadorEventoDeportivo;
    }
    public async Task EjecutarAsync(Guid idEvento, Guid idUsuario)
    {
        var estaAutorizado = await _servicioAutorizacion.EstaAutorizado(idUsuario, Permiso.EventoBaja);
        if (!estaAutorizado)
        {
            throw new FalloAutorizacionException("El usuario no tiene permiso para crear eventos deportivos.");
        }
        var evento = await _repositorioEventoDeportivo.ObtenerPorIDAsync(idEvento);
        if (evento == null)
        {
            throw new ValidacionException("El evento deportivo no existe.");
        }
        if (evento.FechaHoraInicio < DateTime.Now)
        {
            throw new ValidacionException("No se puede eliminar un evento deportivo que ya ha comenzado.");
        }
        var reservas = _repositorioReserva.ObtenerPorEvento(idEvento);
        if (reservas.Count != 0)
        {
            throw new ValidacionException("No se puede eliminar un evento deportivo que tiene reservas asociadas.");
        }
        await _repositorioEventoDeportivo.EliminarAsync(idEvento);
    }

}
