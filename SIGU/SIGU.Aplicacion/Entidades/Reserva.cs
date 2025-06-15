using SIGU.Aplicacion.Excepciones;
namespace SIGU.Aplicacion.Entidades;
public class Reserva
{
    public int Id { get; set; }
    public int PersonaId { get; set; } = 0;
    public int EventoDeportivoId { get; set; } = 0;
    public DateTime FechaAlta { get; set; } = DateTime.Now;
    public Estado EstadoAsistencia { get; set; } = Estado.Pendiente;
    protected Reserva() { }
    public Reserva(int personaId, int eventoDeportivoId)
    {
        if (personaId <= 0) throw new ValidacionException("El ID de la persona no debe estar vacio");
        if (eventoDeportivoId <= 0) throw new ValidacionException("El id de Evento Deportivo no debe estar vacio");
        PersonaId = personaId;
        EventoDeportivoId = eventoDeportivoId;
    }
    // nose si agregar el estado de reserva por defecto , o si se lo deberia setear desde el controlador

    public Reserva(int personaId, int eventoDeportivoId, Estado estadoReserva)
    {
        if (personaId <= 0) throw new ValidacionException("El ID de la persona no debe estar vacio");
        if (eventoDeportivoId <= 0) throw new ValidacionException("El id de Evento Deportivo no debe estar vacio");
        if (estadoReserva == null) throw new ValidacionException("El estado de la reserva no debe estar vacio");
        EstadoReserva = estadoReserva;
        PersonaId = personaId;
        EventoDeportivoId = eventoDeportivoId;
    }


}