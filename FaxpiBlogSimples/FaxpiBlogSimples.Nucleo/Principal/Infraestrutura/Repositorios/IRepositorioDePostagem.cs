using FaxpiBlogSimples.Nucleo.Principal.Dominio;
using FaxpiBlogSimples.Plataforma.Infraestrutura;

using System.Linq.Expressions;

namespace FaxpiBlogSimples.Nucleo.Principal.Infraestrutura.Repositorios
{
  public interface IRepositorioDePostagem : IRepositorio
  {
    void CriarPostagem(Postagem postagem);

    Postagem? Obter(Expression<Func<Postagem, bool>> consulta);

    List<Postagem> Listar(Expression<Func<Postagem, bool>> consulta);

    void Atualizar(Postagem postagem);

    void Excluir(Postagem postagem);
  }
}