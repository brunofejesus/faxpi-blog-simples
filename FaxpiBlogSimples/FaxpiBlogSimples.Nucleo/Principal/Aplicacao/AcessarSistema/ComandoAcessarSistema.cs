using FaxpiBlogSimples.Plataforma.Aplicacao;

namespace FaxpiBlogSimples.Nucleo.Principal.Aplicacao.AcessarSistema
{
  public class ComandoAcessarSistema : IComando
  {
    public string? NomeDeUsuario { get; set; }
    public string? Senha { get; set; }
  }
}