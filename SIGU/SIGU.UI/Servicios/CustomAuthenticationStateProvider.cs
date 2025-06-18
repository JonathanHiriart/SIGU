using Microsoft.AspNetCore.Components.Authorization;
using SIGU.Aplicacion.Entidades;
using System.Security.Claims;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
	private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

	private Usuario? _usuarioActual;

	public void SetUser(Usuario usuario)
	{
		_usuarioActual = usuario;
		NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
	}

	public void Logout()
	{
		_usuarioActual = null;
		NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
	}

	public override Task<AuthenticationState> GetAuthenticationStateAsync()
	{
		if (_usuarioActual == null)
			return Task.FromResult(new AuthenticationState(_anonymous));

		var identity = new ClaimsIdentity(new[]
		{
			new Claim(ClaimTypes.Name, _usuarioActual.Email)
            // Puedes agregar m�s claims aqu� seg�n tus necesidades
        }, "custom");

		var user = new ClaimsPrincipal(identity);
		return Task.FromResult(new AuthenticationState(user));
	}
}