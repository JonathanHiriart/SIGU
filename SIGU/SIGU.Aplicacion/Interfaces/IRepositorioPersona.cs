using SIGU.Aplicacion.Entidades;
namespace SIGU.Aplicacion.Interfaces;

public interface IRepositorioPersona : IRepositorioBase<Persona>
{
    Persona? obtenerPorDNI(string dni);
    Persona? obtenerPorEmail(string email);
}