using SIGU.Aplicacion.Validadores;
using SIGU.Aplicacion.Entidades;
using SIGU.Aplicacion.Excepciones;
using SIGU.Aplicacion.Interfaces;
using SIGU.Aplicacion.DTOs;
namespace SIGU.Aplicacion.CasoDeUso;
public class RegisterUseCase
{
    private readonly IRepositorioUsuario _repositorioUsuario;
    private readonly IHasheador _hasheador;
    private readonly ValidadorUsuario _validadorUsuario;
    public RegisterUseCase(IRepositorioUsuario repositorioUsuario, IHasheador hasheador, ValidadorUsuario validadorUsuario)
    {
        _repositorioUsuario = repositorioUsuario;
        _hasheador = hasheador;
        _validadorUsuario = validadorUsuario;
    }
    public async Task EjecutarAsync(UsuarioDTO usuarioNuevo)
    {
        // este caso de uso se encarga de registrar un nuevo usuario en el sistema sin permisos especiales
        // Hashear la contraseña
        usuarioNuevo.Contrasenia = _hasheador.Hashear(usuarioNuevo.Contrasenia);
        
        Usuario? usuario = new Usuario(usuarioNuevo.Nombre, usuarioNuevo.Apellido, usuarioNuevo.DNI, usuarioNuevo.Email, usuarioNuevo.Telefono, usuarioNuevo.Contrasenia);
        var (esValido, msgError) = await _validadorUsuario.ValidarParaAgregarAsync(usuario);
        if (!esValido)
        {
            throw new ValidacionException(msgError);
        }
        // Guardar el nuevo usuario en el repositorio
        await _repositorioUsuario.AgregarAsync(usuario);
    }
}