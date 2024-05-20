using FaxpiBlogSimples.App.Helpers;
using FaxpiBlogSimples.Nucleo.Principal.Aplicacao.Blog.CriarPostagem;
using FaxpiBlogSimples.Plataforma.Aplicacao;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FaxpiBlogSimples.App.Pages.Blog
{
  public class CriarPostagemModel : PageModel
  {
    private readonly IMediador _mediador;

    public CriarPostagemModel(IMediador mediador)
    {
      _mediador = mediador;
    }

    [BindProperty]
    public ComandoDeCriarPostagem Comando { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      var identificador = UserHelper.ObterIdentificadorDoUsuario(HttpContext!);
      _ = int.TryParse(identificador, out int codigoUsuarioLogado);
      Comando.UsuarioLogado = codigoUsuarioLogado;

      var resposta = _mediador
      .Enviar<ComandoDeCriarPostagem, RespostaDeCriarPostagem>(Comando);

      if (resposta.Sucesso)
      {
        Thread.Sleep(5000);
        return RedirectToPage("/Blog/Index");
      }

      ModelState.AddModelError(string.Empty, resposta.Mensagem);
      return Page();
    }
  }
}