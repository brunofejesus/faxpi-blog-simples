using FaxpiBlogSimples.Nucleo.Principal.Aplicacao.AcessarSistema;
using FaxpiBlogSimples.Plataforma.Aplicacao;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Security.Claims;

namespace FaxpiBlogSimples.App.Pages.Usuario
{
  public class LoginModel : PageModel
  {
    private readonly IMediador _mediador;

    [BindProperty]
    public ComandoAcessarSistema Comando { get; set; }

    public LoginModel(IMediador mediador)
    {
      _mediador = mediador;
    }

    public void OnGet()
    {
      Comando = new ComandoAcessarSistema()
      {
        NomeDeUsuario = "faustosilva@blogsimples.com",
        Senha = "123456"
      };
    }

    public IActionResult OnPost()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      var resposta = _mediador
        .Enviar<ComandoAcessarSistema, RespostaDaAutenticacaoNoSistema>(Comando);

      if (resposta.Sucesso)
      {
        var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
        identity.AddClaim(new Claim(ClaimTypes.Email, Comando.NomeDeUsuario!));
        identity.AddClaim(new Claim("identificador", $"{resposta.Identificador}"));

        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity)).ConfigureAwait(true);

        return RedirectToPage("/Blog/Index");
      }

      ModelState.AddModelError(string.Empty, resposta.Mensagem);
      return Page();
    }
  }
}