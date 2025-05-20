using System.ComponentModel.DataAnnotations;

namespace ListaCompra.Models;

public class Produtos
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo de descrição é obrigatório")]
    [MaxLength(70, ErrorMessage = "O campo de descrição cabe 70 caracteres")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "O campo da unidade é obrigatório")]
    [StringLength(2, ErrorMessage = "O campo de unidade cabe 2 caracteres")]
    public string Unidade { get; set; }

    [Required(ErrorMessage = "O campo de valor é obrigatório")]
    [Range(0.01, 9999.99)]
    public float? Valor { get; set; }

}
