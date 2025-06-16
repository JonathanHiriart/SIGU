using SIGU.Aplicacion.Enums;
using SIGU.Aplicacion.Excepciones;
using SIGU.Aplicacion.Interfaces;
using SIGU.Aplicacion.DTOs;

namespace SIGU.Aplicacion.CasoDeUso;
public class UsuarioModificacionUseCase
{
	private readonly IRepositorioUsuario _repositorioUsuario;
	private readonly IServicioAutorizacion _servicioAutorizacion;
	public UsuarioModificacionUseCase(IRepositorioUsuario repositorioUsuario, IServicioAutorizacion servicioAutorizacion)
	{
		this._repositorioUsuario = repositorioUsuario;
		this._servicioAutorizacion = servicioAutorizacion;
	}
	public async void Ejecutar(Guid IdPersonaAModificar, UsuarioDTO usuarioModificado, Guid IdUsuario)
	{
		// 1. Verificar permiso
		if (!_servicioAutorizacion.EstaAutorizado(IdUsuario, Permiso.UsuarioModificacion))
		{
			throw new FalloAutorizacionException("El usuario no posee el permiso para relizar esta acci�n");
		}

		// 2. Verificar existencia de la persona
		UsuarioDTO? usuario = await _repositorioUsuario.ObtenerPorIDAsync(IdPersonaAModificar);
		if (usuario == null)
		{
			throw new EntidadNotFoundException("El usuario a modificar no existe");
		}
		await _repositorioUsuario.ModificarAsync(usuarioModificado, IdPersonaAModificar);
	}
}