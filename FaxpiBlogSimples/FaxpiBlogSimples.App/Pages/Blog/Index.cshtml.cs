using FaxpiBlogSimples.App.Helpers;
using FaxpiBlogSimples.Nucleo.Principal.Aplicacao.Blog.ObterPostagem;
using FaxpiBlogSimples.Plataforma.Aplicacao;

using Microsoft.AspNetCore.Mvc.RazorPages;

using static FaxpiBlogSimples.Nucleo.Principal.Aplicacao.Blog.ObterPostagem.RespostaDeObterPostagem;

namespace FaxpiBlogSimples.App.Pages.Blog
{
  public class IndexModel : PageModel
  {
    public readonly IMediador _mediador;
    public List<PostagemDto> Postagens { get; set; }

    public IndexModel(IMediador mediador)
    {
      _mediador = mediador;
    }

    public void OnGet()
    {
      var identificador = UserHelper.ObterIdentificadorDoUsuario(HttpContext!);
      _ = int.TryParse(identificador, out int codigoUsuarioLogado);

      var resposta = _mediador.Enviar<ComandoDeObterPostagem, RespostaDeObterPostagem>(
        new ComandoDeObterPostagem()
        {
          CodigoDoUsuario = codigoUsuarioLogado
        });

      if (resposta.Sucesso)
      {
        Postagens = [.. resposta.Postagens];
      }
    }
  }
}