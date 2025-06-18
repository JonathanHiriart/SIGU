using System.ComponentModel.DataAnnotations;

namespace SIGU.Aplicacion.DTOs;

public class UsuarioDTO
{
    public Guid ID { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "El Dni es obligatorio.")]
    public int DNI { get; set; }

    [Required(ErrorMessage = "El apellido es obligatorio.")]
    public string? Apellido { get; set; }

    [Required(ErrorMessage = "El Email es obligatorio.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "El teléfono es obligatorio.")]
    public string? Telefono { get; set; }

    [Required(ErrorMessage = "La contraseña es obligatoria.")]
    public string? Contrasenia { get; set; }
}