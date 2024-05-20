using FaxpiBlogSimples.Nucleo.Principal.Aplicacao.RegistrarUsuario;
using FaxpiBlogSimples.Plataforma.Aplicacao;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FaxpiBlogSimples.App.Pages.Usuario
{
  public class RegistrarModel : PageModel
  {
    private readonly IMediador _mediador;

    [BindProperty]
    public ComandoDeRegistrarUsuario Comando { get; set; }

    public RegistrarModel(IMediador mediador)
    {
      _mediador = mediador;
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      var resposta = _mediador
        .Enviar<ComandoDeRegistrarUsuario, RespostaDoRegistroDoUsuario>(Comando);

      if (resposta.Sucesso)
      {
        return RedirectToPage("/Usuario/Login");
      }

      ModelState.AddModelError(string.Empty, resposta.Mensagem);
      return Page();
    }
  }
}