using SIGU.Aplicacion.DTOs;
using SIGU.Aplicacion.Enums;
using SIGU.Aplicacion.Excepciones;
using SIGU.Aplicacion.Interfaces;
namespace SIGU.Aplicacion.CasoDeUso;
public class UsuarioListadoUseCase
{
    private readonly IRepositorioUsuario _repositorioUsuario;
    private readonly IServicioAutorizacion _servicioAutorizacion;
    public UsuarioListadoUseCase(IRepositorioUsuario repositorioUsuario, IServicioAutorizacion servicioAutorizacion,)
    {
        _repositorioUsuario = repositorioUsuario;
        _servicioAutorizacion = servicioAutorizacion;
    }
    public async Task<List<UsuarioDTO>> Ejecutar(Guid IdUsuario)
    {
        Boolean tienePermiso = await _servicioAutorizacion.EstaAutorizado(IdUsuario, Permiso.UsuarioModificacion);
        if (tienePermiso == false) {
            throw new FalloAutorizacionException("El usuario no tiene permisos para listar usuarios.");
        } else
        {
            List<UsuarioDTO> usuarios = await _repositorioUsuario.ListarAsync() ?? new ;
            if (usuarios.Count == 0)
            {
                return new List<UsuarioDTO>(); // No hay usuarios registrados
            }
            else return usuarios;
        }
    }
}