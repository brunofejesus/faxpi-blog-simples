using FaxpiBlogSimples.Plataforma.Dominio;

namespace FaxpiBlogSimples.Nucleo.Compartilhado.Dominio
{
  public abstract class Entidade<T> : IEntidade
  {
    public T? Id { get; set; }
  }
}