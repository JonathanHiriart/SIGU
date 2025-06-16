using SIGU.Aplicacion.Enums;
namespace SIGU.Aplicacion.Entidades;
public class Usuario
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Nombre { get; private set; } = "";
    public string DNI { get; private set; } = "";
    public string Apellido { get; private set; } = "";
    public string Email { get; private set; } = "";
    public string Telefono { get; private set; } = "";
    public string Contrasenia { get; private set; } = "";
    public List<Permiso> Permisos { get; private set; } = new List<Permiso>();

    protected Usuario() { }
    public Usuario(string nombre, string apellido, string dni, string email, string telefono, string contrasenia)
    {
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.DNI = dni;
        this.Email = email;
        this.Telefono = telefono;
        this.Contrasenia = contrasenia;
    }

}