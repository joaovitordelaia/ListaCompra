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


}
