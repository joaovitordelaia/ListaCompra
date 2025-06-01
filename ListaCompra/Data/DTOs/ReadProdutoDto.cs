using System.ComponentModel.DataAnnotations;

namespace ListaCompra.Data.DTOs;

public class ReadProdutoDto
{

    public string Descricao { get; set; }

    public float? Valor { get; set; }

    public float? Quantity { get; set; }

    public DateTime HoraConsulta { get; set; } = DateTime.Now;
}
