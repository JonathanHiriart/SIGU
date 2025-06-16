namespace SIGU.Aplicacion.DTOs;

public class UsuarioDTO
{
    public Guid Id { get; set; }= Guid.Empty;
    public string Nombre { get; set; } = string.Empty;
    public int DNI { get; set; } = 0;
    public string Apellido { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string Contrasenia { get; set; } = string.Empty;
    
}