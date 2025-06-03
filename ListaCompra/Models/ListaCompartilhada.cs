namespace ListaCompra.Models;

public class ListaCompartilhada
{
    public int? UsuarioId { get; set; }

    public virtual Usuario Usuario { get; set; }

    public int? ListaId { get; set; }

    public virtual ListaDeCompras listaId { get; set; }
}
