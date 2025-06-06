using AutoMapper;
using ListaCompra.Data;
using ListaCompra.Data.DTOs;
using ListaCompra.Models;
using ListaCompra.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ListaCompra.Controllers;

[Route("[Controller]")]
[Produces("application/json")]
public class UsuarioController : ControllerBase
{
    private UsuarioService _usuarioService;

    public UsuarioController(UsuarioService cadastroService)
    {
        _usuarioService = cadastroService;
    }



    /// <summary>
    /// Cadastra um novo usuário no sistema
    /// </summary>
    /// <param name="Dto">Dados para criação do usuário</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Usuário criado com sucesso</response>
    /// <remarks>
    /// Envie no corpo da requisição um JSON com as informações do usuário.
    /// </remarks>
    [HttpPost("CadastrarUsuario")]
    public async Task<IActionResult> Cadastro([FromBody] CreateUsuarioDto Dto)
    {
        await _usuarioService.Cadastro(Dto);
        return Ok("usuário criado com sucesso!");
    }


    /// <summary>
    /// Realiza o login de um usuário
    /// </summary>
    /// <param name="dto">Credenciais do usuário</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Token gerado com sucesso</response>
    /// <remarks>
    /// Retorna o token JWT necessário para chamadas autenticadas.
    /// </remarks>
    [HttpPost("LoginUsuario")]
    // pois as infos do usuario sera passada pelo corpo da requisição
    public async Task<IActionResult> Login([FromBody] LoginUsuarioDto dto)
    {
        var token = await _usuarioService.Login(dto);
        return Ok(token);
    }

}