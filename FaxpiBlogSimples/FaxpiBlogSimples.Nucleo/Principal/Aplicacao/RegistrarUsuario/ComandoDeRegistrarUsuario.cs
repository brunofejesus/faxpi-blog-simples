using FaxpiBlogSimples.Plataforma.Aplicacao;

namespace FaxpiBlogSimples.Nucleo.Principal.Aplicacao.RegistrarUsuario
{
  public class ComandoDeRegistrarUsuario : IComando
  {
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Senha { get; set; }
  }
}