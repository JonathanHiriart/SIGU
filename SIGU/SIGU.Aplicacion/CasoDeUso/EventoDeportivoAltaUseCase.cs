using SIGU.Aplicacion.DTOs;
using SIGU.Aplicacion.Entidades;
using SIGU.Aplicacion.Excepciones;
using SIGU.Aplicacion.Interfaces;
using SIGU.Aplicacion.Validadores;
namespace SIGU.Aplicacion.CasoDeUso;
public class EventoDeportivoAltaUseCase
{
    private readonly IRepositorioEventoDeportivo _repositorioEventoDeportivo;
    private readonly IRepositorioPersona _repositorioPersona;
    private readonly IServicioAutorizacion _servicioAutorizacion;

    public EventoDeportivoAltaUseCase(IRepositorioEventoDeportivo repositorioEventoDeportivo,IRepositorioPersona repositorioPersona, IServicioAutorizacion servicioAutorizacion)
    {
        _repositorioEventoDeportivo = repositorioEventoDeportivo ?? throw new ArgumentNullException(nameof(repositorioEventoDeportivo), "El repositorio de eventos deportivos no puede ser nulo.");
        _repositorioPersona = repositorioPersona ?? throw new ArgumentNullException(nameof(repositorioPersona), "El repositorio de personas no puede ser nulo.");
        _servicioAutorizacion = servicioAutorizacion;
    }
    public async Task<EventoDeportivo> EjecutarAsync(EventoDeportivoDTO dto, Guid idUsuario)
    {
        if (!_servicioAutorizacion.EstaAutorizado(idUsuario, Enums.Permiso.EventoAlta))
        {
            throw new FalloAutorizacionException("El usuario no tiene permisos para crear eventos deportivos.");
        }
        var responsable = await _repositorioPersona.ObtenerPorIDAsync(dto.ResponsableId);

        if (responsable == null)
        {
            throw new ValidacionException("El responsable del evento deportivo no existe.");
        }
        ValidadorEventoDeportivo validador = new ValidadorEventoDeportivo(_repositorioPersona);
        EventoDeportivo evento = new EventoDeportivo(dto.Nombre, dto.Descripcion, dto.FechaHoraInicio, dto.DuracionHoras, dto.CupoMaximo, dto.ResponsableId);
        if (validador.Validar(evento, out string msgError) == false)
        {
            throw new ValidacionException(msgError);
        }
        await _repositorioEventoDeportivo.AgregarAsync(evento);

        return evento;
    }

}
