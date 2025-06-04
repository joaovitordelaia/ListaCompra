using ListaCompra.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ListaCompra.Data;

public class ApplicationDbContext : IdentityDbContext<Usuario>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<ListaCompartilhadas>()
            .HasKey(listaCompartilhada => new { listaCompartilhada.UsuarioId, listaCompartilhada.ListaId });

        builder.Entity<ListaCompartilhadas>()

            .HasOne(listaCompartilhada => listaCompartilhada.Lista)

            .WithMany(ListaCompra => ListaCompra.ListaCompartilhada)

            .HasForeignKey(listaCompartilhada => listaCompartilhada.ListaId);

        builder.Entity<ListaCompartilhadas>()

            .HasOne(listaCompartilhada => listaCompartilhada.Usuario)

            .WithMany(Usuario => Usuario.ListaCompartilhada)

            .HasForeignKey(listaCompartilhada => listaCompartilhada.UsuarioId);

        builder.Entity<ListaCompartilhadas>()
                .Property(p => p.Datacriacao)
                .HasDefaultValueSql("GETDATE()");

        builder.Entity<ListaDeCompras>()
            .Property(p => p.Datacriacao)
            .HasDefaultValueSql("GETDATE()");

    }

    public DbSet<Produtos> Produtos { get; set; }
    public DbSet<ListaDeCompras> ListaDeCompras { get; set; }
    public DbSet<ListaCompartilhadas> ListaCompartilhada { get; set; }
}

