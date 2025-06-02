using ListaCompra.Data.DTOs;
using ListaCompra.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



namespace ListaCompra.Service
{
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _singInManeger;
        private TokenService _tokenService;

        public UsuarioService(SignInManager<Usuario> singInManeger, UserManager<Usuario> userManager, IMapper mapper, TokenService tokenService = null)
        {
            _mapper = mapper;
            _userManager = userManager;
            _singInManeger = singInManeger;
            _tokenService = tokenService;
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

        public  async Task<string> Login(LoginUsuarioDto dto)
        {
            var resultadoLogin = await _singInManeger.PasswordSignInAsync
                (dto.Username, dto.Password, false, false);

            if (!resultadoLogin.Succeeded)
            {
                throw new ApplicationException("Dados invalidos");
            }

            var usuario = _singInManeger.UserManager.Users.FirstOrDefault(
                    user => user.NormalizedUserName == dto.Username.ToUpper());

            var token = _tokenService.GenerateToken(usuario);

            return token;

        }
    }
}
