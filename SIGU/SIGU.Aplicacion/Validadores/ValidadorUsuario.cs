using SIGU.Aplicacion.Excepciones;
using SIGU.Aplicacion.Entidades;
using SIGU.Aplicacion.Interfaces; 
using SIGU.Aplicacion.DTOs;
namespace SIGU.Aplicacion.Validadores;

public class ValidadorUsuario
{
    private readonly IRepositorioUsuario _repositorio;

    public ValidadorUsuario(IRepositorioUsuario u)
    {
        this._repositorio = u;
    }

    public bool Validador(UsuarioDTO usuario, out string mensaje)
    {
        mensaje = "";
        if (string.IsNullOrWhiteSpace(usuario.Nombre))
        {
            mensaje += "El nombre no puede estar vacio \n";
        }

        if (string.IsNullOrWhiteSpace(usuario.Apellido))
        {
            mensaje += "El apellido no puede estar vacio \n";
        }

        if ((usuario.DNI == 0))
        {
            mensaje += "El DNI no puede estar vacio \n";
        }

        if (string.IsNullOrWhiteSpace(usuario.Email))
        {
            mensaje += "El email no puede estar vacio \n";
        }

        if (!(usuario.DNI==0) && _repositorio.obtenerPorDni(usuario.DNI) != null)
        {
            mensaje += "El DNI ya existe \n";
            throw new DuplicadoException("Ya existe una persona con ese DNI");
        }

        if (!string.IsNullOrWhiteSpace(usuario.Email) && _repositorio.obtenerPorEmail(usuario.Email) != null)
        {
            mensaje += "El email ya existe \n";
            throw new DuplicadoException("Ya existe una persona con ese email");
        }

        return mensaje == "";
    }
}