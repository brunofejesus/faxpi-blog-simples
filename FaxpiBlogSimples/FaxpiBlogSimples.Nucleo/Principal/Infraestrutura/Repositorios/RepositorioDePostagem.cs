using FaxpiBlogSimples.Nucleo.Compartilhado.Infraestrutura.Repositorios;
using FaxpiBlogSimples.Nucleo.Principal.Dominio;

using System.Linq.Expressions;

namespace FaxpiBlogSimples.Nucleo.Principal.Infraestrutura.Repositorios
{
  public class RepositorioDePostagem : RepositorioBase<ContextoDePrincipal>, IRepositorioDePostagem
  {
    public RepositorioDePostagem(ContextoDePrincipal contexto) : base(contexto)
    {
    }

    public void Atualizar(Postagem postagem)
    {
      base.Atualizar(postagem);
    }

    public void CriarPostagem(Postagem postagem)
    {
      Inserir(postagem);
    }

    public void Excluir(Postagem postagem)
    {
      Apagar(postagem);
    }

    public List<Postagem> Listar(Expression<Func<Postagem, bool>> consulta)
    {
      return base.Listar(consulta).ToList();
    }

    public Postagem? Obter(Expression<Func<Postagem, bool>> consulta)
    {
      return base.Obter(consulta);
    }
  }
}