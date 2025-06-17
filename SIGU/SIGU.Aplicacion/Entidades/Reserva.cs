using SIGU.Aplicacion.Enums;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace SIGU.Aplicacion.Entidades;
public class Reserva
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid usuarioID { get; set; }
    public Guid EventoDeportivoId { get; set; } 
    public DateTime FechaAlta { get; set; } = DateTime.Now;
    public Estado EstadoAsistencia { get; set; } = Estado.Pendiente;
    public EventoDeportivo EventoDeportivo { get; set; } = null!;
    public Usuario Usuario { get; set; } = null!;
    protected Reserva() { }

    public Reserva(Guid usuarioId, Guid eventoDeportivoId)
    {
        if (usuarioId == Guid.Empty) throw new ArgumentException("El ID del usuario no puede ser nulo.");
        if (eventoDeportivoId == Guid.Empty) throw new ArgumentException("El ID del evento deportivo no puede ser nulo.");
        this.usuarioID = usuarioId;
        this.EventoDeportivoId = eventoDeportivoId;
    }
    public void ActualizarDatos(Guid usuarioID, Guid EventoDeportivoId, DateTime FechaAlta, Estado EstadoAsistencia, EventoDeportivo EventoDeportivo, Usuario Usuario)
    {
        this.usuarioID = usuarioID;
        this.EventoDeportivoId = EventoDeportivoId;
        this.FechaAlta = FechaAlta;
        this.EstadoAsistencia = EstadoAsistencia;
        this.Usuario = Usuario;
        this.EventoDeportivo = EventoDeportivo;
        this.Usuario = Usuario;
    }
}