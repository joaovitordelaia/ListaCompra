namespace ListaCompra.Models;

public class ListaCompartilhadas
{
    public string? UsuarioId { get; set; }

    public virtual Usuario Usuario { get; set; }

    public int? ListaId { get; set; }

    public virtual ListaDeCompras Lista { get; set; }
}
