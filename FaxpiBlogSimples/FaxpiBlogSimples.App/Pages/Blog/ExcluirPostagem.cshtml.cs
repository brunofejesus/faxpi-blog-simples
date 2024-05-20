using FaxpiBlogSimples.App.Helpers;
using FaxpiBlogSimples.Nucleo.Principal.Aplicacao.Blog.ExcluirPostagem;
using FaxpiBlogSimples.Plataforma.Aplicacao;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FaxpiBlogSimples.App.Pages.Blog
{
  public class ExcluirModel : PageModel
  {
    private readonly IMediador _mediador;

    public ExcluirModel(IMediador mediador)
    {
      _mediador = mediador;
    }

    public IActionResult OnGet(int? id)
    {
      if (id.HasValue)
      {
        var identificador = UserHelper.ObterIdentificadorDoUsuario(HttpContext!);
        _ = int.TryParse(identificador, out int codigoUsuarioLogado);

        _ = _mediador
          .Enviar<ComandoDeExcluirPostagem, RespostaDeExcluirPostagem>(new ComandoDeExcluirPostagem()
          {
            PostagemId = id.Value,
            UsuarioLogado = codigoUsuarioLogado
          });
      }

      return RedirectToPage("/Blog/Index");
    }
  }
}