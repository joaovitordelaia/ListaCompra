using AutoMapper;
using ListaCompra.Data;
using ListaCompra.Data.DTOs;
using ListaCompra.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace ListaCompra.Controllers;

//[Authorize]
[Route("[controller]")]
[Produces("application/json")]

public class ProdutoController : ControllerBase
{
    private ApplicationDbContext _context;
    private IMapper _mapper;

    public ProdutoController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Cadastra um novo produto
    /// </summary>
    /// <param name="produtoDto">Dados do produto</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Produto criado com sucesso</response>
    /// <remarks>Salva o produto e retorna o endereço para consulta.</remarks>
    [HttpPost("CadastrarProduto")]
    public IActionResult CriarProduto([FromBody] CreateProdutoDto produtoDto)
    {
        //if (!ModelState.IsValid)
        //    return BadRequest(ModelState);

        Produtos produto = _mapper.Map<Produtos>(produtoDto);
        _context.Produtos.Add(produto);
        _context.SaveChanges();

        return CreatedAtAction(nameof(RecuperaProdutoPorId), new { id = produto.Id }, produto);
    }

    /// <summary>
    /// Lista todos os produtos
    /// </summary>
    /// <returns>Coleção de produtos</returns>
    [HttpGet("RecuperarProdutos")]
    public IEnumerable<ReadProdutoDto> LerProdutos()
    {
        var produto = _context.Produtos.ToList();
        return _mapper.Map<List<ReadProdutoDto>>(produto);

    }

    /// <summary>
    /// Recupera um produto pelo ID
    /// </summary>
    /// <param name="id">Identificador do produto</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Produto encontrado</response>
    /// <response code="404">Produto não encontrado</response>
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

    /// <summary>
    /// Atualiza parcialmente um produto
    /// </summary>
    /// <param name="id">Identificador do produto</param>
    /// <param name="patch">Operações a serem aplicadas</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Produto atualizado com sucesso</response>
    /// <response code="404">Produto não encontrado</response>
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