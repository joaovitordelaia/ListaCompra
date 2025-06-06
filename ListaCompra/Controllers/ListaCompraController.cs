using AutoMapper;
using ListaCompra.Data;
using ListaCompra.Models;
using ListaCompra.Data.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ListaCompra.Controllers;

[Route("[controller]")]
[Produces("application/json")]
public class ListaCompraController : ControllerBase
{
    private IMapper _mapper;
    private ApplicationDbContext _contexto;

    public ListaCompraController(IMapper mapper, ApplicationDbContext contexto)
    {
        _mapper = mapper;
        _contexto = contexto;
    }


    [HttpPost("CriarLista")]
                    
    public IActionResult CriarListaCompra([FromBody] CreateListaComprasDto ListaDto)
    {
        ListaDeCompras listaCompra = _mapper.Map<ListaDeCompras>(ListaDto);
        _contexto.ListaDeCompras.Add(listaCompra);
        _contexto.SaveChanges();

        return CreatedAtAction(nameof(ListarListaCompraPorId), new { id = listaCompra.Id}, listaCompra);
    }

    [HttpGet("ListarListasPorId/{id}")]
    public IActionResult ListarListaCompraPorId(int id)
    {
        var listasDeCompra = _contexto.ListaDeCompras.FirstOrDefault(Listas => Listas.Id == id);
        if (listasDeCompra == null) return NotFound();

        var listaDto = _mapper.Map<ReadListaCompraDto>(listasDeCompra);
        return Ok(listaDto);

    }

    [HttpGet("ListarListas")]
    public IEnumerable<ReadListaCompraDto> ListarListaCompra()
    {
        var listasDeCompra = _contexto.ListaDeCompras.ToList();

        var listaDto = _mapper.Map<List<ReadListaCompraDto>>(listasDeCompra);
        return listaDto;

    }

    [HttpDelete("DeletarListaCompra/{id}")]
    public IActionResult DeletarListaCompra(int id)
    {
        var listaCompra = _contexto.ListaDeCompras.FirstOrDefault(listaCompra => listaCompra.Id == id);
        if (listaCompra != null)
        {
            _contexto.Remove(listaCompra);
            _contexto.SaveChanges();
            return NoContent();
        }
        return NotFound();
    }


}
