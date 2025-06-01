using System.ComponentModel.DataAnnotations;

namespace ListaCompra.Data.DTOs;

public class CreateUsuarioDto
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public DateTime DataNascimento { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    public string Senha { get; set; }

    [Compare("Senha")]
    public string ReSenha { get; set; }
}
