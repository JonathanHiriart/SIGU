using SIGU.Aplicacion.Enums;
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

}