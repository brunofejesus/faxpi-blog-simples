using FaxpiBlogSimples.Nucleo.Principal.Aplicacao.Blog.ObterPostagem;
using FaxpiBlogSimples.Plataforma.Aplicacao;

using Microsoft.AspNetCore.Mvc.RazorPages;

using static FaxpiBlogSimples.Nucleo.Principal.Aplicacao.Blog.ObterPostagem.RespostaDeObterPostagem;

namespace FaxpiBlogSimples.App.Pages
{
  public class IndexModel : PageModel
  {
    private readonly ILogger<IndexModel> _logger;

    public readonly IMediador _mediador;

    public List<PostagemDto> Postagens { get; set; }

    public IndexModel(ILogger<IndexModel> logger, IMediador mediador)
    {
      _logger = logger;
      _mediador = mediador;
    }

    public void OnGet()
    {
      var resposta = _mediador.Enviar<ComandoDeObterPostagem, RespostaDeObterPostagem>(
        new ComandoDeObterPostagem());

      if (resposta.Sucesso)
      {
        Postagens = [.. resposta.Postagens];
      }
    }
  }
}