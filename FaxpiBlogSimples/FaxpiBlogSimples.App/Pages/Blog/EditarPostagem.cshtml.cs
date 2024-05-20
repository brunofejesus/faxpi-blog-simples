using FaxpiBlogSimples.App.Helpers;
using FaxpiBlogSimples.Nucleo.Principal.Aplicacao.Blog.EditarPostagem;
using FaxpiBlogSimples.Nucleo.Principal.Aplicacao.Blog.ObterPostagem;
using FaxpiBlogSimples.Plataforma.Aplicacao;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FaxpiBlogSimples.App.Pages.Blog
{
  public class EditarPostagemModel : PageModel
  {
    private readonly IMediador _mediador;

    [BindProperty]
    public ComandoDeEditarPostagem Comando { get; set; }

    public EditarPostagemModel(IMediador mediador)
    {
      _mediador = mediador;
    }

    public void OnGet(int? id)
    {
      if (id.HasValue)
      {
        var identificador = UserHelper.ObterIdentificadorDoUsuario(HttpContext!);
        _ = int.TryParse(identificador, out int codigoUsuarioLogado);

        var resposta = _mediador
          .Enviar<ComandoDeObterPostagem, RespostaDeObterPostagem>(new ComandoDeObterPostagem()
          {
            PostagemId = id.Value,
            CodigoDoUsuario = codigoUsuarioLogado
          });

        if (resposta.Sucesso)
        {
          Comando = new ComandoDeEditarPostagem()
          {
            Titulo = resposta.Postagens?.FirstOrDefault()?.Titulo,
            Conteudo = resposta.Postagens?.FirstOrDefault()?.Conteudo,
            PostagemId = resposta.Postagens?.FirstOrDefault()?.PostagemId,
          };
        }
      }
    }

    public IActionResult OnPost()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      var identificador = UserHelper.ObterIdentificadorDoUsuario(HttpContext!);
      _ = int.TryParse(identificador, out int codigoUsuarioLogado);
      Comando.UsuarioLogado = codigoUsuarioLogado;

      var resposta = _mediador
      .Enviar<ComandoDeEditarPostagem, RespostaDeEditarPostagem>(Comando);

      if (resposta.Sucesso)
      {
        return RedirectToPage("/Blog/Index");
      }

      ModelState.AddModelError(string.Empty, resposta.Mensagem);
      return Page();
    }
  }
}