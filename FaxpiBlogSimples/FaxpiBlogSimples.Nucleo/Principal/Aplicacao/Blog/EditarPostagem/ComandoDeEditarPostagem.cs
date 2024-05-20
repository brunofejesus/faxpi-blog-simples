using FaxpiBlogSimples.Plataforma.Aplicacao;

namespace FaxpiBlogSimples.Nucleo.Principal.Aplicacao.Blog.EditarPostagem
{
  public class ComandoDeEditarPostagem : IComando
  {
    public int? PostagemId { get; set; }
    public string? Titulo { get; set; } = string.Empty;
    public string? Conteudo { get; set; } = string.Empty;
    public int UsuarioLogado { get; set; }
  }
}