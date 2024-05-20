using FaxpiBlogSimples.Nucleo.Principal.Dominio;
using FaxpiBlogSimples.Nucleo.Principal.Infraestrutura.Servicos;

using Microsoft.EntityFrameworkCore;

using Npgsql;

namespace FaxpiBlogSimples.Nucleo.Principal.Infraestrutura.Repositorios
{
  public class InicializadorDoContextoDePrincipal
  {
    private readonly ContextoDePrincipal _context;
    private readonly IManipuladorDeSenha _manipuladorDeSenha;

    public InicializadorDoContextoDePrincipal(
      ContextoDePrincipal context,
      IManipuladorDeSenha manipuladorDeSenha)
    {
      _context = context;
      _manipuladorDeSenha = manipuladorDeSenha;
    }

    public async Task InitialiseAsync()
    {
      try
      {
        if (_context.Database.IsNpgsql())
        {
          var pendingMigrations = await _context.Database.GetPendingMigrationsAsync();

          if (pendingMigrations.Any())
          {
            await _context.Database.MigrateAsync();
          }
        }
      }
      catch
      {
        throw;
      }
    }

    public async Task SeedAsync()
    {
      try
      {
        await TrySeedAsync();
      }
      catch
      {
        throw;
      }
    }

    public async Task TrySeedAsync()
    {
      var usuario = new Usuario(
          "Fausto Silva",
          nomeDeUsuario: "faustosilva@blogsimples.com",
      "faustosilva@blogsimples.com"
      );

      string senhaEmbaralhada = _manipuladorDeSenha.GerarHash("123456");
      usuario.AtualizarSenha(senhaEmbaralhada);

      await _context.Database.OpenConnectionAsync();
      ((NpgsqlConnection)_context.Database.GetDbConnection()).ReloadTypes();
      var usuarios = await _context.Usuarios.ToListAsync();

      if (usuarios.Count == 0)
      {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
      }
    }
  }
}