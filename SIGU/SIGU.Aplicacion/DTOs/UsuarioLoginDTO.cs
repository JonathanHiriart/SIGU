using System.ComponentModel.DataAnnotations;

namespace SIGU.Aplicacion.DTOs;

public class UsuarioLoginDTO
{

    [Required(ErrorMessage = "El Email es obligatorio.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "La Contrase�a es obligatoria.")]
    public string Contrase�a { get; set; } = string.Empty;
}