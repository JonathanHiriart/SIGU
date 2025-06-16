using SIGU.Aplicacion.Interfaces;
using SIGU.Aplicacion.Entidades;
using SIGU.Aplicacion.Enums;   
namespace SIGU.Aplicacion.Servicios;

public class ServicioAutorizacion : IServicioAutorizacion
{
    private readonly IServicioAutorizacion _servicioAutorizacion;
    public ServicioAutorizacion(IServicioAutorizacion servicioAutorizacion)
    {
        _servicioAutorizacion = servicioAutorizacion;
    }
    public bool EstaAutorizado(Usuario Usuario, Permiso permiso)
    {
        if(persona == null)
        {
            throw new ArgumentNullException("La persona no puede ser nula.");
        }
        if(!Enum.IsDefined(typeof(Permiso), permiso))
        {
            throw new ArgumentException("El permiso especificado no es valido.");
        }
        return _servicioAutorizacion.EstaAutorizado(persona, permiso);
    }
}