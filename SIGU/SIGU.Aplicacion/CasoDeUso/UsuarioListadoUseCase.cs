using SIGU.Aplicacion.DTOs;
using SIGU.Aplicacion.Entidades;
using SIGU.Aplicacion.Enums;
using SIGU.Aplicacion.Excepciones;
using SIGU.Aplicacion.Interfaces;
namespace SIGU.Aplicacion.CasoDeUso;
public class UsuarioListadoUseCase
{
    private readonly IRepositorioUsuario _repositorioUsuario;
    private readonly IServicioAutorizacion _servicioAutorizacion;
    public UsuarioListadoUseCase(IRepositorioUsuario repositorioUsuario, IServicioAutorizacion servicioAutorizacion)
    {
        _repositorioUsuario = repositorioUsuario;
        _servicioAutorizacion = servicioAutorizacion;
    }
    public async Task<List<UsuarioDTO>> Ejecutar(Guid IdUsuario)
    {
        bool tienePermiso = await _servicioAutorizacion.EstaAutorizado(IdUsuario, Permiso.UsuarioListar);
        if (!tienePermiso)
        {
            throw new FalloAutorizacionException("El usuario no tiene permisos para listar usuarios.");
        }
        List<Usuario> usuarios = await _repositorioUsuario.ListarAsync() ?? new List<Usuario>();
        if (usuarios.Count == 0)
        {
            throw new ValidacionException("No se encontraron usuarios.");
        }
        // Listando con el DTO Evitamos exponer la entidad Usuario directamente
        var usuariosDTO = usuarios.Select(u => new UsuarioDTO
        {
            ID = u.Id,
            Nombre = u.Nombre,
            Apellido = u.Apellido,
            DNI = u.DNI,
            Email = u.Email,
            Telefono = u.Telefono,
            Contrasenia = u.Contrasenia
        }).ToList();

        return usuariosDTO;
    }
}