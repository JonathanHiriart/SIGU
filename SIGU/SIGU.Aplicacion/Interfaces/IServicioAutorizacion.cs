using SIGU.Aplicacion.Entidades;
using SIGU.Aplicacion.Enums;

namespace SIGU.Aplicacion.Interfaces;
public interface IServicioAutorizacion
{
    Task<bool> EstaAutorizado(Guid IdUsuario,Permiso permiso);
}