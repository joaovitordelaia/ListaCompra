using ListaCompra.Models;
using System.ComponentModel.DataAnnotations;

namespace ListaCompra.Data.DTOs;

public class CreateProdutoDto
{
    [Required(ErrorMessage = "O campo de descrição é obrigatório")]
    [MaxLength(70, ErrorMessage = "O campo de descrição cabe 70 caracteres")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "O campo de valor é obrigatório")]
    [Range(0.01, 9999.99)]
    public float? Valor { get; set; }

    [Required(ErrorMessage = "A quantidade é obrigatório")]
    [Range(0.01, 9999.99)]
    public float? Quantidade { get; set; }

    public int? listaDeComprasId { get; set; }

    public bool StatusProd { get; set; } = true;
}
