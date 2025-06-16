using SIGU.Aplicacion.Entidades;
using SIGU.Aplicacion.Interfaces;
using SIGU.Aplicacion.Excepciones;
using SIGU.Aplicacion.Validadores;
using SIGU.Aplicacion.Enums;
using SIGU.Aplicacion.DTOs;
namespace SIGU.Aplicacion.CasoDeUso;


public class UsuarioAltaUseCase
{
    private readonly IRepositorioUsuario _repositorioUsuario;
    private readonly IServicioAutorizacion _servicioAutorizacion;
    private readonly IHasheador _hasheador;
    private readonly ValidadorUsuario _validadorUsuario;
    public UsuarioAltaUseCase(IRepositorioUsuario repositorioUsuario, IServicioAutorizacion servicioAutorizacion, IHasheador hasheador, ValidadorUsuario validador)
    {
        _repositorioUsuario = repositorioUsuario;
        _servicioAutorizacion = servicioAutorizacion;
        _validadorUsuario =  validador;
        _hasheador = hasheador;
    }
    public async Task EjecutarAsync(UsuarioDTO usuario, Guid idUsuario)
    {
        if (!_servicioAutorizacion.EstaAutorizado(idUsuario, Permiso.UsuarioAlta))
        {
            throw new FalloAutorizacionException("El usuario no tiene permisos para crear nuevos usuarios.");
        }
        if (!_validadorUsuario.Validador(usuario, out string mensaje)) {
            throw new ValidacionException(mensaje);
        }
        usuario.Contrasenia = _hasheador.Hashear(usuario.Contrasenia);
        await _repositorioUsuario.AgregarAsync(usuario);
    }
}