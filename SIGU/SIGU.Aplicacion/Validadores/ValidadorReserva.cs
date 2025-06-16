using SIGU.Aplicacion.Entidades;
using SIGU.Aplicacion.Interfaces;

namespace SIGU.Aplicacion.Validadores;
public class ValidadorReserva
{
    private readonly IRepositorioUsuario _repositorioUsuario;
    private readonly IRepositorioEventoDeportivo _repositorioEventoDeportivo;
    private readonly IRepositorioReserva _repositorioReserva;
    public ValidadorReserva(IRepositorioUsuario repositorioUsuario, IRepositorioEventoDeportivo repositorioEventoDeportivo, IRepositorioReserva repositorioReserva)
    {
        _repositorioUsuario = repositorioUsuario;
        _repositorioEventoDeportivo = repositorioEventoDeportivo;
        _repositorioReserva = repositorioReserva;
    }
    public async Task<(bool esValido, string msgError)> ValidarParaAgregarAsync(Reserva reserva)
    {
        string msgError = "";
        if (reserva == null)
        {
            msgError = "La reserva no puede ser nula.";
            return (false, msgError);
        }
        var (valido,errorComun) = await ValidarPersonaYEvento(reserva.PersonaId, reserva.EventoDeportivoId);
        if (!valido)
        {
            return (false, errorComun);
        }
        Reserva? yaReservado = await _repositorioReserva.ObtenerPorPersonaYEventoAsync(reserva.PersonaId, reserva.EventoDeportivoId);
        if (yaReservado != null)
        {
            msgError = "La persona ya tiene una reserva para este evento deportivo.";
            return (false, msgError);
        }
        return (true, msgError);
    }
    public async Task<(bool esValido, string msgError)> ValidarParaModificarAsync(Reserva reserva)
    {
        string msgError = "";
        if (reserva == null)
        {
            msgError = "La reserva no puede ser nula.";
            return (false, msgError);
        }
        var (valido, errorComun) = await ValidarPersonaYEvento(reserva.PersonaId, reserva.EventoDeportivoId);
        if (!valido)
        {
            return (false, errorComun);
        }
        Reserva? yaReservado = await _repositorioReserva.ObtenerPorPersonaYEventoAsync(reserva.PersonaId, reserva.EventoDeportivoId);
        if (yaReservado == null)
        {
            msgError = "La Reserva a modificar no existe.";
            return (false, msgError);
        }
        return (true, msgError);
    }
    private async Task<(bool esValido, string msgError)> ValidarPersonaYEvento(Guid personaId, Guid eventoId)
    {
        if (personaId == Guid.Empty)
            return (false, "El ID de la persona no puede ser nulo.");

        var persona = await _repositorioUsuario.ObtenerPorIDAsync(personaId);
        if (persona == null)
            return (false, "La persona no existe.");

        if (eventoId == Guid.Empty)
            return (false, "El ID del evento deportivo no puede ser nulo.");

        var evento = await _repositorioEventoDeportivo.ObtenerPorIDAsync(eventoId);
        if (evento == null)
            return (false, "El evento deportivo no existe.");

        return (true, "");
    }
}