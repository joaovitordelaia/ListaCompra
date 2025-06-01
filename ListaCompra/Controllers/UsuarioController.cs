using AutoMapper;
using ListaCompra.Data;
using ListaCompra.Data.DTOs;
using ListaCompra.Models;
using ListaCompra.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ListaCompra.Controllers;

[Route("[Controller]")]
[Produces("application/json")]
public class UsuarioController : ControllerBase
{
    private CadastroService _cadastroService;

    public UsuarioController(CadastroService cadastroService)
    {
        _cadastroService = cadastroService;
    }



    [HttpPost("CadastrarUsuario")]
    public async Task<IActionResult> Cadastro([FromBody]CreateUsuarioDto Dto)
    {
            await _cadastroService.Cadastro(Dto);
            return Ok("usuário criado com sucesso!");
    }

}
