using ListaCompra.Models;

namespace ListaCompra.Data.DTOs;

public class CreateListaComprasDto
{
    public string Nome { get; set; }

    public DateTime Datacriacao { get; set; } = DateTime.Now;

    public string? UsuarioId { get; set; }

}
