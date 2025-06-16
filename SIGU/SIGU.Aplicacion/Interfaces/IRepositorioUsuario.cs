using SIGU.Aplicacion.Entidades;
using SIGU.Aplicacion.DTOs;
namespace SIGU.Aplicacion.Interfaces;

public interface IRepositorioUsuario : IRepositorioBase<UsuarioDTO>
{
    Task<UsuarioDTO> obtenerPorDni(int dni);
    Task<UsuarioDTO> obtenerPorEmail(string email);
}