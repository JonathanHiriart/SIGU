using SIGU.Aplicacion.Entidades;
using SIGU.Aplicacion.Enums;

namespace SIGU.Aplicacion.Interfaces;
public interface IServicioAutorizacion
{
    bool EstaAutorizado(Persona persona,Permiso permiso);
}