using SIGU.Aplicacion.DTOs;
using SIGU.Aplicacion.Entidades;
using SIGU.Aplicacion.Enums;
using SIGU.Aplicacion.Excepciones;
using SIGU.Aplicacion.Interfaces;
namespace SIGU.Aplicacion.CasoDeUso;
public class UsuaruioListadoUseCase
{
    private readonly IRepositorioReserva _repositorioReserva;
    private readonly IServicioAutorizacion _servicioAutorizacion;
    public UsuaruioListadoUseCase(IRepositorioReserva repositorioUsuario, IServicioAutorizacion servicioAutorizacion)
    {
        _repositorioReserva = repositorioUsuario;
        _servicioAutorizacion = servicioAutorizacion;
    }
    public async Task<List<ReservaDTO>> Ejecutar(Guid IdUsuario)
    {
        bool tienePermiso = await _servicioAutorizacion.EstaAutorizado(IdUsuario, Permiso.ReservaListar);
        if (!tienePermiso)
        {
            throw new FalloAutorizacionException("El usuario no tiene permisos para listar reserva.");
        }
        List<Reserva> reservas= await _repositorioReserva.ListarAsync() ?? new List<Reserva>();
        if (reservas.Count == 0)
        {
            throw new ValidacionException("No se encontraron usuarios.");
        }
        // Listando con el DTO Evitamos exponer la entidad Usuario directamente
        var reservaDTO = reservas.Select(u => new ReservaDTO
        {

            PersonaId = u.usuarioID,
            EventoDeportivoId = u.EventoDeportivoId,
            FechaAlta = u.FechaAlta,
            EstadoAsistencia = u.EstadoAsistencia
        }).ToList();

        return reservaDTO;
    }
}