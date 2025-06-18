using SIGU.Aplicacion.Entidades;

namespace SIGU.Aplicacion.Servicios;

public class UsuarioServicioLogin
{
	private Usuario usuario { get; set; } = null!;

	private bool _logueado = false;

	public UsuarioServicioLogin() {
		usuario = null!;
		_logueado = false;
    }
    public void SetUser(Usuario user) { 
		usuario = user;
	}

	public Usuario GetUser() {
		if (usuario == null) {
			throw new InvalidOperationException("No se pudo obtener el usuario");
		}
		return usuario;
	}

	public void Logueado() {
		_logueado = true;
	}

	public Guid recuperarID() {
		if (usuario == null) {
			throw new InvalidOperationException("No se pudo recuperar el ID del usuario porque no está logueado o el usuario es nulo.");
		}
		return usuario.Id;
	}

}