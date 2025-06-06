using ListaCompra.Models;
using System.ComponentModel.DataAnnotations;

namespace ListaCompra.Data.DTOs;

public class ReadProdutoDto
{

    public string Descricao { get; set; }

    public float? Valor { get; set; }

    public float? Quantidade { get; set; }

    public int? ListaDeComprasId { get; set; }

    public bool StatusProd { get; set; }

    public DateTime HoraConsulta { get; set; } = DateTime.Now;
}
