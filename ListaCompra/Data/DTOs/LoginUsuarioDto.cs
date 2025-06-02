using System.ComponentModel.DataAnnotations;

namespace ListaCompra.Data.DTOs;

public class LoginUsuarioDto
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}
