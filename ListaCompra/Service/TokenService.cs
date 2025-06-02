
using ListaCompra.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ListaCompra.Service;

public class TokenService
{

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

        var chave = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("F3SI9894FIOHWWEWEVCVCX76554615REWO94FIOHUY3428"));

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