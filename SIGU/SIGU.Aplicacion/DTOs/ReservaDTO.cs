using SIGU.Aplicacion.Enums;
namespace SIGU.Aplicacion.DTOs;

public class ReservaDTO
{
    public Guid PersonaId { get; set; }
    public Guid EventoDeportivoId { get; set; }
    public Estado EstadoAsistencia { get; set; }
    public DateTime FechaAlta { get; set; }

}