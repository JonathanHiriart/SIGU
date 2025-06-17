using SIGU.Aplicacion.DTOs;
using SIGU.Aplicacion.Entidades;
using SIGU.Aplicacion.Enums;
using SIGU.Aplicacion.Excepciones;
using SIGU.Aplicacion.Interfaces;
using SIGU.Aplicacion.Validadores;

namespace SIGU.Aplicacion.CasoDeUso;
public class UsuarioModificacionUseCase
{
	private readonly IRepositorioUsuario _repositorioUsuario;
	private readonly IServicioAutorizacion _servicioAutorizacion;
	private readonly IHasheador _hasheador;
	private readonly ValidadorUsuario _validadorUsuario;
    public UsuarioModificacionUseCase(IRepositorioUsuario repositorioUsuario, IServicioAutorizacion servicioAutorizacion, IHasheador hasheador,ValidadorUsuario validadorUsuario)
	{
		this._repositorioUsuario = repositorioUsuario;
		this._servicioAutorizacion = servicioAutorizacion;
		this._hasheador = hasheador;
		this._validadorUsuario = validadorUsuario;
    }
	public async void Ejecutar(Guid IdPersonaAModificar, UsuarioDTO usuarioModificado, Guid IdUsuario)
	{
		// 1. Verificar permiso
		bool tienePermiso = await _servicioAutorizacion.EstaAutorizado(IdUsuario, Permiso.UsuarioModificacion);
        if (tienePermiso == false)
		{
			throw new FalloAutorizacionException("El usuario no posee el permiso para relizar esta acci�n");
		}
        // 2. Verificar existencia de la persona
        Usuario? usuario = await _repositorioUsuario.ObtenerPorIDAsync(IdPersonaAModificar);
        if (usuario == null)
        {
            throw new EntidadNotFoundException("El usuario a eliminar no existe");
        }
        // 3. Validar datos del usuario modificado
        usuarioModificado.Contrasenia = _hasheador.Hashear(usuarioModificado.Contrasenia);
        Usuario? usuarioModificar = new Usuario(usuarioModificado.Nombre, usuarioModificado.Apellido, usuarioModificado.DNI, usuarioModificado.Email, usuarioModificado.Telefono, usuarioModificado.Contrasenia);
		var (esValido, msgError) = await _validadorUsuario.ValidarParaModificarAsync(usuarioModificar);
		if (!esValido)
		{
			throw new ValidacionException(msgError);
		}
        // 4. Modificar usuario
        await _repositorioUsuario.ModificarAsync(usuarioModificar, IdPersonaAModificar);
	}
}