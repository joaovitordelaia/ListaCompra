using AutoMapper;
using ListaCompra.Data;
using ListaCompra.Data.DTOs;
using ListaCompra.Models;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ListaCompra.Controllers;

[Route("[controller]")]
[Produces("application/json")]
public class ListaCompartilhadaController : ControllerBase
{
    private IMapper _mapper;
    private ApplicationDbContext _contexto;

    public ListaCompartilhadaController(IMapper mapper, ApplicationDbContext contexto)
    {
        _mapper = mapper;
        _contexto = contexto;
    }


    [HttpPost("CriarVinculoComp")]
    public IActionResult AdicionaListaCompartilhada([FromBody]CreateListaCompartilhadaDto dto)
    {
        ListaCompartilhadas listaCompartilhada = _mapper.Map<ListaCompartilhadas>(dto);
        _contexto.ListaCompartilhada.Add(listaCompartilhada);
        _contexto.SaveChanges();

        return CreatedAtAction(nameof(RecuperaListaCompartPorId),
            new { usuarioId = listaCompartilhada.UsuarioId, listaId = listaCompartilhada.ListaId }, listaCompartilhada);
    }


    [HttpGet("vinculo/{usuarioId}/{listaId}")]
    public IActionResult RecuperaListaCompartPorId(string usuarioId, int listaId)
    {
        ListaCompartilhadas listaCompartilhada = _contexto.ListaCompartilhada.FirstOrDefault(listaCompart => listaCompart.UsuarioId == usuarioId && listaCompart.ListaId == listaId);
        if (listaCompartilhada != null)
        {
            ReadListaCompartilhadaDto listaCompartiDto = _mapper.Map<ReadListaCompartilhadaDto>(listaCompartilhada);

            return Ok(listaCompartiDto);
        }
        return NotFound();
    }

    [HttpGet("RecuperaListaUser")]
    public IEnumerable<ReadListaCompartilhadaDto> RecuperaListaUsuario()
    {
        return _mapper.Map<List<ReadListaCompartilhadaDto>>(_contexto.ListaCompartilhada.ToList());
    }


    [HttpDelete("DeletarListaCompartilhada/{usuarioId}/{listaId}")]
    public IActionResult DeletarListaCompartilhada(string usuarioId, int listaId)
    {
        var listaCompartilhada = _contexto.ListaCompartilhada.FirstOrDefault(listaCompartilhada => listaCompartilhada.UsuarioId == usuarioId && listaCompartilhada.ListaId == listaId);
        if (listaCompartilhada != null)
        {
            _contexto.Remove(listaCompartilhada);
            _contexto.SaveChanges();
            return NoContent();
        }

        return NotFound();

        
    }

}
