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
        bool tienePermiso= await _servicioAutorizacion.EstaAutorizado(idUsuario, Permiso.UsuarioAlta);
        if (tienePermiso== false)
        {
            throw new FalloAutorizacionException("El usuario no tiene permisos para crear nuevos usuarios.");
        }
        usuario.Contrasenia = _hasheador.Hashear(usuario.Contrasenia);
        Usuario? usuarioAgregar = new Usuario(usuario.Nombre, usuario.Apellido,usuario.DNI ,usuario.Email,usuario.Telefono, usuario.Contrasenia);

        var (esValido, msgError) = await _validadorUsuario.ValidarParaAgregarAsync(usuarioAgregar);
        if (!esValido) {
            throw new ValidacionException(msgError);
        }
        await _repositorioUsuario.AgregarAsync(usuarioAgregar);
    }
}