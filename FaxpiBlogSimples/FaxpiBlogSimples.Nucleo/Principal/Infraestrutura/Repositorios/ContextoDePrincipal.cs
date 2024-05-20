using FaxpiBlogSimples.Nucleo.Principal.Dominio;
using FaxpiBlogSimples.Nucleo.Principal.Infraestrutura.Mapeamentos;

using Microsoft.EntityFrameworkCore;

namespace FaxpiBlogSimples.Nucleo.Principal.Infraestrutura.Repositorios
{
  public class ContextoDePrincipal : DbContext
  {
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Postagem> Postagem => Set<Postagem>();

    public ContextoDePrincipal(DbContextOptions<ContextoDePrincipal> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new MapeamentoDeUsuario());
      modelBuilder.ApplyConfiguration(new MapeamentoDePostagem());
      base.OnModelCreating(modelBuilder);
    }
  }
}