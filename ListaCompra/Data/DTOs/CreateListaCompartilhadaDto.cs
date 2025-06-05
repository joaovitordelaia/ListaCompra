namespace ListaCompra.Data.DTOs;

public class CreateListaCompartilhadaDto
{
    public string UsuarioId { get; set; }
    public int ListaId { get; set; }
    public DateTime Datacriacao { get; set; } = DateTime.Now;
}
