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
		Boolean tienePermiso = await _servicioAutorizacion.EstaAutorizado(IdUsuario, Permiso.UsuarioModificacion);
        if (tienePermiso == false)
		{
			throw new FalloAutorizacionException("El usuario no posee el permiso para relizar esta acci�n");
		}

		await _repositorioUsuario.ModificarAsync(usuarioModificado, IdPersonaAModificar);
	}
}