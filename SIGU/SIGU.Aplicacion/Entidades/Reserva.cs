using SIGU.Aplicacion.Enums;
namespace SIGU.Aplicacion.Entidades;
public class Reserva
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid PersonaId { get; set; }
    public Guid EventoDeportivoId { get; set; } 
    public DateTime FechaAlta { get; set; } = DateTime.Now;
    public Estado EstadoAsistencia { get; set; } = Estado.Pendiente;
    protected Reserva() { }

}