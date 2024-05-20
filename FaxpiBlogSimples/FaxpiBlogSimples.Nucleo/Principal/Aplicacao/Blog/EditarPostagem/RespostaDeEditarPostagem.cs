using FaxpiBlogSimples.Nucleo.Compartilhado.Aplicacao;

namespace FaxpiBlogSimples.Nucleo.Principal.Aplicacao.Blog.EditarPostagem
{
  public class RespostaDeEditarPostagem : RespostaBasica
  {
    private const string MensagemDeSucesso = "Postagem editada com sucesso!";
    private const string MensagemDePostagemNaoEncontrada = "Não foi possível editar, postagem não encontrada";

    public RespostaDeEditarPostagem(bool sucesso, string mensagem) : base(sucesso, mensagem)
    {
    }

    public static RespostaDeEditarPostagem DeSucesso()
    {
      return new RespostaDeEditarPostagem(true, MensagemDeSucesso);
    }

    public static RespostaDeEditarPostagem DeNaoEncontrada()
    {
      return new RespostaDeEditarPostagem(sucesso: false, MensagemDePostagemNaoEncontrada);
    }
  }
}