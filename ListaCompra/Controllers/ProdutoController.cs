using AutoMapper;
using ListaCompra.Data;
using ListaCompra.Data.DTOs;
using ListaCompra.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace ListaCompra.Controllers;

[Route("[Controller]")]
[Produces("application/json")]
public class ProdutoController : ControllerBase
{
    private ProdutoContext _context;
    private IMapper _mapper;

    public ProdutoController(ProdutoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpPost("CadastrarProduto")]
    public IActionResult CriarProduto([FromBody] CreateProdutoDto produtoDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        Produtos produto = _mapper.Map<Produtos>(produtoDto);
        _context.Produtos.Add(produto);
        _context.SaveChanges();

        return CreatedAtAction(nameof(RecuperaProdutoPorId), new { id = produto.Id }, produto);
    }

    [HttpGet("RecuperarProdutos")]
    public IEnumerable<ReadProdutoDto> LerProdutos()
    {
        var produto = _context.Produtos.ToList();
        return _mapper.Map<List<ReadProdutoDto>>(produto);

    }

    [HttpGet("RecuperarProdutosID/{id}")]
    public IActionResult RecuperaProdutoPorId(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
        if (produto == null) return NotFound();

        var produtoDto = _mapper.Map<ReadProdutoDto>(produto);
        return Ok(produtoDto);

    }



    /// <summary>
    /// Deleta um produto do BD
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <param name="id">Codigo identificador</param>
    /// <response code="204">Produto deletado com sucesso</response>
    /// <response code="404">caso não encontre pelo id o que a requisição pediu</response>
    /// <remarks>
    /// Remove permanentemente o Produto do banco de dados pelo ID informado.
    /// Exemplo de uso: /Filme/Deletar/5
    /// Retorna 204 se deletado com sucesso ou 404 se o Produto não for encontrado.
    /// </remarks>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("DeletarProduto/{id}")]
    public IActionResult DeletarProduto(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
        if (produto == null) return NotFound();

        _context.Remove(produto);
        _context.SaveChanges();
        return NoContent();

    }

    [HttpPatch("AtualizaParcialProduto/{id}")]
    public IActionResult AtualizaParcial(int id, [FromBody] JsonPatchDocument<UpdateProdutoDto> patch)
    {
        var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
        if (produto == null) return NotFound();

        var produtoAtualizar = _mapper.Map<UpdateProdutoDto>(produto);

        patch.ApplyTo(produtoAtualizar, ModelState);

        if (!TryValidateModel(produtoAtualizar))
        {
            return ValidationProblem(ModelState);
        
        }

        _mapper.Map(produtoAtualizar, produto);
        _context.SaveChanges();
        return NoContent();
        //return NoContent();

    }

}
