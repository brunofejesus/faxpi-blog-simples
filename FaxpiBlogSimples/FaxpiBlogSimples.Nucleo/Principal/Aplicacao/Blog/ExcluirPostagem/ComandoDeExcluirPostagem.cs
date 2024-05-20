using FaxpiBlogSimples.Plataforma.Aplicacao;

namespace FaxpiBlogSimples.Nucleo.Principal.Aplicacao.Blog.ExcluirPostagem
{
  public class ComandoDeExcluirPostagem : IComando
  {
    public int PostagemId { get; set; }
    public int UsuarioLogado { get; set; }
  }
}