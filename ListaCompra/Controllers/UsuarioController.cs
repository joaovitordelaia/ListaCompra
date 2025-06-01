using AutoMapper;
using ListaCompra.Data;
using ListaCompra.Data.DTOs;
using ListaCompra.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ListaCompra.Controllers;

[Route("[Controller]")]
[Produces("application/json")]
public class UsuarioController : ControllerBase
{
    private ProdutoContext _context;
    private IMapper _mapper;
    private UserManager<Usuario> _userManager;

    public UsuarioController(ProdutoContext context, IMapper mapper, UserManager<Usuario> userManager)
    {
        _mapper = mapper;
        _context = context;
        _userManager = userManager;
    }

    [HttpPost("CadastrarUsuario")]
    public async Task<IActionResult> Cadastro([FromBody]CreateUsuarioDto Dto)
    {
        Usuario usuario = _mapper.Map<Usuario>(Dto);
        IdentityResult resposta = await _userManager.CreateAsync(usuario, Dto.Senha);

        if (resposta.Succeeded) return Ok("usuário criado com sucesso!");
        
        throw new ApplicationException("Falha no cadastro!!{resposta.Errors}");

    }

}
