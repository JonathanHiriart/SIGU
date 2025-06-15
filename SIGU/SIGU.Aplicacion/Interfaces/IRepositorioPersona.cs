using SIGU.Aplicacion.Entidades;
namespace SIGU.Aplicacion.Interfaces;

public interface IRepositorioPersona : IRepositorioBase<Persona>
{
    Task<Persona?> obtenerPorDniAsync(string dni);
    Task<Persona?> obtenerPorEmailAsync(string email);
}