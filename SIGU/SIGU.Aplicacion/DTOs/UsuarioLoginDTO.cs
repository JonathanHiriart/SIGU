using System.ComponentModel.DataAnnotations;

namespace SIGU.Aplicacion.DTOs;

public class UsuarioLoginDTO
{

    [Required(ErrorMessage = "El Email es obligatorio.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "La Contraseņa es obligatoria.")]
    public string Contraseņa { get; set; } = string.Empty;
}