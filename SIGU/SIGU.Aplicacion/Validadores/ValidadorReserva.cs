using SIGU.Aplicacion.Entidades;
using SIGU.Aplicacion.Excepciones;
using SIGU.Aplicacion.Interfaces;

namespace SIGU.Aplicacion.Validadores;
public class ValidadorReserva
{
    private readonly IRepositorioUsuario _repositorioUsuario;
    private readonly IRepositorioEventoDeportivo _repositorioEventoDeportivo;
    private readonly IRepositorioReserva _repositorioR;
    private readonly I
    public ValidadorReserva(IRepositorioUsuario repositorioUsuario, IRepositorioEventoDeportivo repositorioEventoDeportivo, IRepositorioReserva repositorioReserva)
    {
        _repositorioUsuario = repositorioUsuario;
        _repositorioEventoDeportivo = repositorioEventoDeportivo;
        _repositorioR = repositorioReserva;
    }
    public bool Validar(Reserva reserva, out string mensaje)
    {
        mensaje = "";
        if (_repositorioUsuario.ObtenerPorIDAsync(reserva.PersonaId) == null)
        {
            mensaje += "El ID de la persona no existe \n";
            throw new EntidadNotFoundException("El ID de la persona no existe");
        }
        if (_repositorioED.ObtenerPorID(reserva.EventoDeportivoId) == null)
        {
            mensaje += "El ID del evento deportivo no existe \n";
            throw new EntidadNotFoundException("El ID del evento deportivo no existe");
        }
        if (_repositorioR.ObtenerPorPersonaYEvento(reserva.PersonaId, reserva.EventoDeportivoId) != null)
        {
            mensaje += "Ya existe una reserva para esta persona en este evento deportivo \n";
        }
        var reservas = _repositorioR.ObtenerPorEvento(reserva.EventoDeportivoId);
        var evento = _repositorioED.ObtenerPorID(reserva.EventoDeportivoId);
        if (reservas.Count >= evento.CupoMaximo)
        {
            mensaje += "No hay cupo disponible para este evento deportivo \n";
        }

        return mensaje == "";


    }

}