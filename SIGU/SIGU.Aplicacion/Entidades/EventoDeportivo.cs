namespace SIGU.Aplicacion.Entidades;
public class EventoDeportivo
{
    public int Id { get; set; } // debe ser autoIncrementada por el repositorio
    public string? Nombre { get; set; } = "";
    public string? Descripcion {get;set;} = "";
    public DateTime FechaHoraInicio { get; set; } = DateTime.Now;
    public double DuracionHoras{get;set;} = 0;
    public int CupoMaximo {get;set;} = 0;
    public int ResponsbleID { get; set; } = 0;
}