
using ListaCompra.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ListaCompra.Service;

public class TokenService
{
    private IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(Usuario usuario)
    {
        Claim[] claim = new Claim[]
        {
            new Claim("id", usuario.Id),
            new Claim("username", usuario.UserName),
            new Claim(ClaimTypes.DateOfBirth, usuario.DataNascimento.ToString()),
            new Claim(ClaimTypes.Email, usuario.Email),
            new Claim("loginTimestamp", DateTime.UtcNow.ToString())
        };

        var chave = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(_configuration["SymmetricSecurityKey"]));

        var signingCredentials =
            new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken
            (
                expires: DateTime.Now.AddMinutes(20),
                claims: claim,
                signingCredentials: signingCredentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);

    }
}