using FaxpiBlogSimples.Plataforma.Aplicacao;

namespace FaxpiBlogSimples.Nucleo.Principal.Aplicacao.Blog.ObterPostagem
{
  public class ComandoDeObterPostagem : IComando
  {
    public int? PostagemId { get; set; }
    public int? CodigoDoUsuario { get; set; }
  }
}