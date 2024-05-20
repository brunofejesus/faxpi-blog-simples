using FaxpiBlogSimples.Nucleo.Compartilhado.Aplicacao;

namespace FaxpiBlogSimples.Nucleo.Principal.Aplicacao.Blog.ExcluirPostagem
{
  public class RespostaDeExcluirPostagem : RespostaBasica
  {
    private const string MensagemDeSucesso = "Postagem excluída com sucesso";
    private const string MensagemDeErro = "Erro ao excluir postagem";

    public RespostaDeExcluirPostagem(bool sucesso, string mensagem) : base(sucesso, mensagem)
    {
    }

    public static RespostaDeExcluirPostagem DeSucesso()
    {
      return new RespostaDeExcluirPostagem(true, MensagemDeSucesso);
    }

    public static RespostaDeExcluirPostagem DeErro()
    {
      return new RespostaDeExcluirPostagem(sucesso: false, MensagemDeErro);
    }
  }
}