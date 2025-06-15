using System.ComponentModel.DataAnnotations;
using SIGU.Aplicacion.Excepciones;
namespace SIGU.Aplicacion.Entidades;
public class EventoDeportivo
{
    public int Id { get; private set;}
    public string? Nombre { get; set; } = "";
    public string? Descripcion {get;set;} = "";
    public DateTime FechaHoraInicio { get; set; } = DateTime.Now;
    public double DuracionHoras{get;set;} = 0;
    public int CupoMaximo {get;set;} = 0;
    public int ResponsbleID { get; set; } = 0;
    protected EventoDeportivo() { }

    public EventoDeportivo(string? nombre, string? descripcion, DateTime fechaInicio, double duracion, int cupo, int responsable)
    {
        if (string.IsNullOrWhiteSpace(nombre)) throw new ValidacionException("El nombre no puede ser nulo ni estar vacio");
        if (string.IsNullOrWhiteSpace(descripcion)) throw new ValidacionException("La descripcion no puede ser nula ni estar vacia");
        if (duracion <= 0) throw new ValidacionException("La duracion no puede ser menor o igual a 0");
        if (cupo <= 0) throw new ValidacionException("El cupo no puede ser menor o igual a 0");
        if (responsable <= 0) throw new ValidacionException("El responsable no puede ser menor o igual a 0");
        if (fechaInicio < DateTime.Now) throw new ValidacionException("La fecha de inicio no puede ser menor a la fecha actual");
        Nombre = nombre;
        Descripcion = descripcion;
        FechaHoraInicio = fechaInicio;
        DuracionHoras = duracion;
        CupoMaximo = cupo;
        ResponsbleID = responsable;
    }
}