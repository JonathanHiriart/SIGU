
using SIGU.Aplicacion.Entidades;
using SIGU.Aplicacion.Interfaces;

namespace SIGU.Aplicacion.Validadores;

public class ValidadorEventoDeportivo
{
    private readonly IRepositorioUsuario _repositorioUsuario;

    public ValidadorEventoDeportivo(IRepositorioUsuario p)
    {
        _repositorioUsuario= p;
    }

    public bool Validar(EventoDeportivo eDeportivo, out string msgError)
    {
        msgError = "";
        if (eDeportivo == null)
        {
            msgError = "El evento deportivo no puede ser nulo.";
        } else 
            {
                if (string.IsNullOrWhiteSpace(eDeportivo.Nombre))
                {
                    msgError = "El nombre del evento deportivo no puede ser nulo ni estar vacío.";
                }
                if (string.IsNullOrWhiteSpace(eDeportivo.Descripcion))
                {
                    msgError = "La descripción del evento deportivo no puede ser nula ni estar vacía.";

                }
                if (eDeportivo.DuracionHoras <= 0)
                {
                    msgError = "La duración del evento deportivo no puede ser menor o igual a 0 horas.";
                }
                if (eDeportivo.CupoMaximo <= 0)
                {
                    msgError = "El cupo máximo del evento deportivo no puede ser menor o igual a 0.";
                }
                if (eDeportivo.FechaHoraInicio < DateTime.Now)
                {
                    msgError = "La fecha y hora de inicio del evento deportivo no puede ser menor a la fecha y hora actual.";
                }
                if (eDeportivo.ResponsbleID == Guid.Empty)
                {
                    msgError = "El responsable del evento deportivo no puede ser nulo.";
                }
                else
                {
                    var responsable = _repositorioUsuario.ObtenerPorIDAsync(eDeportivo.ResponsbleID);
                    if (responsable == null)
                    {
                        msgError = "El responsable del evento deportivo no existe.";
                    }
                }
             
            }

        return msgError == "";
    }
}