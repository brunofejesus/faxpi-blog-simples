using FaxpiBlogSimples.Nucleo.Principal.Dominio;

using System.Linq.Expressions;

namespace FaxpiBlogSimples.Nucleo.Principal.Infraestrutura.Repositorios.Filtros
{
  public static class FiltroDePostagem
  {
    public static Expression<Func<Postagem, bool>> PorUsuarioPostagemId(int? postagemId, int? codigoUsuario)
    {
      if (postagemId.HasValue && codigoUsuario.HasValue)
      {
        return p => p.Id == postagemId && p.UsuarioId == codigoUsuario;
      }

      if (postagemId.HasValue)
      {
        return p => p.Id == postagemId;
      }

      if (codigoUsuario.HasValue)
      {
        return p => p.UsuarioId == codigoUsuario;
      }

      return p => true;
    }
  }
}