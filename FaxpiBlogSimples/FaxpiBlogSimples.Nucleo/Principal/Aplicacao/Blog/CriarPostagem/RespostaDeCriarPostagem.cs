using FaxpiBlogSimples.Nucleo.Compartilhado.Aplicacao;

namespace FaxpiBlogSimples.Nucleo.Principal.Aplicacao.Blog.CriarPostagem
{
  public class RespostaDeCriarPostagem : RespostaBasica
  {
    private const string MensagemDeSucesso = "Postagem criada com sucesso!";

    public RespostaDeCriarPostagem(bool sucesso, string mensagem) : base(sucesso, mensagem)
    {
    }

    public static RespostaDeCriarPostagem DeSucesso()
    {
      return new RespostaDeCriarPostagem(true, MensagemDeSucesso);
    }
  }
}