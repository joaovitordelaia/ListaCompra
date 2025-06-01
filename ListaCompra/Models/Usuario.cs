using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ListaCompra.Models;

public class Usuario : IdentityUser
{
    public DateTime DataNascimento { get; set; }
    public Usuario() : base() { }

}
