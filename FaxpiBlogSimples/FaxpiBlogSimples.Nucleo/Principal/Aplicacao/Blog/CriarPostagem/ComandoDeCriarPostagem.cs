using FaxpiBlogSimples.Plataforma.Aplicacao;

namespace FaxpiBlogSimples.Nucleo.Principal.Aplicacao.Blog.CriarPostagem
{
  public class ComandoDeCriarPostagem : IComando
  {
    public string Titulo { get; set; } = string.Empty;
    public string Conteudo { get; set; } = string.Empty;
    public int UsuarioLogado { get; set; }
  }
}