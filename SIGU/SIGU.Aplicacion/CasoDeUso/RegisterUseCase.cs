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
        if(string.IsNullOrEmpty(usuarioNuevo.Contrasenia))
        {
            throw new ValidacionException("La contraseña no puede ser nula o vacía.");
        }
        usuarioNuevo.Contrasenia = _hasheador.Hashear(usuarioNuevo.Contrasenia);

        // Validación adicional para evitar argumentos nulos
        if (string.IsNullOrEmpty(usuarioNuevo.Nombre))
        {
            throw new ArgumentException("El nombre no puede ser nulo o vacío.");
        }
        if (string.IsNullOrEmpty(usuarioNuevo.Apellido))
        {
            throw new ArgumentException("El apellido no puede ser nulo o vacío.");
        }
        if (string.IsNullOrEmpty(usuarioNuevo.Email))
        {
            throw new ArgumentException("El email no puede ser nulo o vacío.");
        }
        if (string.IsNullOrEmpty(usuarioNuevo.Telefono))
        {
            throw new ArgumentException("El teléfono no puede ser nulo o vacío.");
        }
        // Crear una instancia de Usuario a partir del DTO
        Usuario? usuario = new Usuario(usuarioNuevo.Nombre, usuarioNuevo.Apellido, usuarioNuevo.DNI, usuarioNuevo.Email, usuarioNuevo.Telefono, usuarioNuevo.Contrasenia,usuarioNuevo.permisos);
        var (esValido, msgError) = await _validadorUsuario.ValidarParaAgregarAsync(usuario);
        if (!esValido)
        {
            throw new ValidacionException(msgError);
        }
        // Guardar el nuevo usuario en el repositorio
        await _repositorioUsuario.AgregarAsync(usuario);
    }
}