using ListaCompra.Models;

namespace ListaCompra.Data.DTOs;

public class ReadListaCompraDto
{
    public string Nome { get; set; }

    public DateTime Datacriacao { get; set; } = DateTime.Now;

    //por ter que trazer só o nome não se dever por o modelo do usario aqui apenas o que ele vai ser enviado
    // no caso quero apenas o nome, então posso por somente a propriedade que sera exibida
    public string UsuarioCriador { get; set; }

    public virtual ICollection<ReadProdutoDto> Produtos { get; set; }
}
