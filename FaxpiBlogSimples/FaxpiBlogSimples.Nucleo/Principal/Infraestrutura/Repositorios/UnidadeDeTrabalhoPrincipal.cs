using FaxpiBlogSimples.Nucleo.Compartilhado.Infraestrutura.Repositorios;

namespace FaxpiBlogSimples.Nucleo.Principal.Infraestrutura.Repositorios
{
  public class UnidadeDeTrabalhoPrincipal : UnidadeDeTrabalhoBase<ContextoDePrincipal>, IUnidadeDeTrabalhoPrincipal
  {
    public UnidadeDeTrabalhoPrincipal(ContextoDePrincipal contexto) : base(contexto)
    {
    }
  }
}