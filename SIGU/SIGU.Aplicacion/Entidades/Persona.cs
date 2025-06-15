using System.ComponentModel.DataAnnotations;
using SIGU.Aplicacion.Excepciones;
using SIGU.Aplicacion.Enums;
namespace SIGU.Aplicacion.Entidades;
public class Persona
{
    public int Id { get; private set; } 
    public string Nombre { get; set; } = "";
    public string DNI { get; set; } = "";
    public string Apellido { get; set; } = "";
    public string Email { get; set; } = "";
    public string Telefono { get; set; } = "";
    public List<Permiso> Permisos { get; set; } = new List<Permiso>();

    protected Persona() { }
    public Persona(string nombre, string apellido, string dni, string email, string telefono)
    {
        if (string.IsNullOrWhiteSpace(nombre)) throw new ValidacionException("El nombre no puede ser nulo ni estar vacio");
        if (string.IsNullOrWhiteSpace(dni)) throw new ValidacionException("El DNI no puede ser nulo estar vacio");
        if (string.IsNullOrWhiteSpace(email)) throw new ValidacionException("El mail no puede ser nulo ni estar vacio");
        if (Email != null && !EmailValido(email)) throw new ValidacionException("El formato del mail no es válido.");
        if (DNIValido(dni) == false) throw new ValidacionException("El formato del DNI no es válido.");
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.DNI = dni;
        this.Email = email;
        this.Telefono = telefono;
    }
    public static bool EmailValido(string email)
    {
        return email.Contains("@") && email.Contains(".") && email.IndexOf("@") < email.IndexOf(".");
    }

    public static bool DNIValido(string dni)
    {
        return dni.Length >= 7 && dni.Length <= 8 && int.TryParse(dni, out _);
    }
}