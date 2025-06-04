using System.ComponentModel.DataAnnotations;

namespace ListaCompra.Models;


public class ListaDeCompras
{
    [Required]
    public int Id { get; set; }

    public string Nome { get; set; }

    public DateTime Datacriacao { get; set; }

    public string? UsuarioId { get; set; }

    public virtual Usuario UsuarioCriador { get; set; }

    public virtual ICollection<Produtos> Produtos { get; set; }

    public virtual ICollection<ListaCompartilhadas> ListaCompartilhada { get; set; }

}
