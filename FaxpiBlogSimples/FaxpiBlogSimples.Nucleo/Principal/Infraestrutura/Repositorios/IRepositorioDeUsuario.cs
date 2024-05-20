using FaxpiBlogSimples.Nucleo.Principal.Dominio;
using FaxpiBlogSimples.Plataforma.Infraestrutura;

using System.Linq.Expressions;

namespace FaxpiBlogSimples.Nucleo.Principal.Infraestrutura.Repositorios
{
  public interface IRepositorioDeUsuario : IRepositorio
  {
    Usuario? Obter(Expression<Func<Usuario, bool>> consulta);

    void RegistrarUsuario(Usuario usuario);
  }
}