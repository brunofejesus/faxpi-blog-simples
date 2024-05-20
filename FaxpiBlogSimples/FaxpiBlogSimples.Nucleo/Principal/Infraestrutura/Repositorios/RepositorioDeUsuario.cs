using FaxpiBlogSimples.Nucleo.Compartilhado.Infraestrutura.Repositorios;
using FaxpiBlogSimples.Nucleo.Principal.Dominio;

using System.Linq.Expressions;

namespace FaxpiBlogSimples.Nucleo.Principal.Infraestrutura.Repositorios
{
  public class RepositorioDeUsuario : RepositorioBase<ContextoDePrincipal>, IRepositorioDeUsuario
  {
    public RepositorioDeUsuario(ContextoDePrincipal contexto) : base(contexto)
    {
    }

    public Usuario? Obter(Expression<Func<Usuario, bool>> consulta)
    {
      return base.Obter(consulta);
    }

    public void RegistrarUsuario(Usuario usuario)
    {
      Inserir(usuario);
    }
  }
}