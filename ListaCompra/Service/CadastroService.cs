using ListaCompra.Data.DTOs;
using ListaCompra.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



namespace ListaCompra.Service
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;
        public CadastroService(UserManager<Usuario> userManager, IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
        }


        public async Task Cadastro(CreateUsuarioDto dto)
        {
            Usuario usuario = _mapper.Map<Usuario>(dto);
            IdentityResult resposta = await _userManager.CreateAsync(usuario, dto.Senha);
            if (!resposta.Succeeded)
            {
                throw new ApplicationException("Falha no cadastro!!{resposta.Errors}");
            }
            
        }
    }
}
