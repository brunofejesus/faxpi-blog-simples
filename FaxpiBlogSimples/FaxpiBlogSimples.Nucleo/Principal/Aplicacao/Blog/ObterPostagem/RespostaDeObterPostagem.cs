using FaxpiBlogSimples.Nucleo.Compartilhado.Aplicacao;
using FaxpiBlogSimples.Nucleo.Principal.Dominio;

namespace FaxpiBlogSimples.Nucleo.Principal.Aplicacao.Blog.ObterPostagem
{
  public class RespostaDeObterPostagem : RespostaBasica
  {
    private const string MensagemDeSucesso = "Postagens obtidas com sucesso!";
    public List<PostagemDto> Postagens { get; set; } = new();

    public RespostaDeObterPostagem(bool sucesso, string mensagem) : base(sucesso, mensagem)
    {
    }

    private RespostaDeObterPostagem(bool sucesso, string mensagem, List<PostagemDto> postagens) : base(sucesso, mensagem)
    {
      Postagens = [.. postagens];
    }

    public static RespostaDeObterPostagem DeSucesso(List<Postagem> postagens)
    {
      return new(
        true,
        MensagemDeSucesso,
          postagens.Select(p => new PostagemDto()
          {
            PostagemId = p?.Id,
            Titulo = p?.Titulo,
            Conteudo = p?.Conteudo,
            DataDeCriacao = p?.DataDaCriacao
          }).ToList()
        );
    }

    public sealed class PostagemDto
    {
      public int? PostagemId { get; set; }
      public string? Titulo { get; set; }
      public string? Conteudo { get; set; }
      public DateTime? DataDeCriacao { get; set; }
    }
  }
}