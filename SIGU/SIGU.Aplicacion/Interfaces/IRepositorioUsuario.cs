using SIGU.Aplicacion.Entidades;
using SIGU.Aplicacion.DTOs;
namespace SIGU.Aplicacion.Interfaces;

public interface IRepositorioUsuario : IRepositorioBase<Usuario>
{
    Task<Usuario> obtenerPorDni(string dni);
    Task<Usuario> obtenerPorEmail(string email);
}