using FaxpiBlogSimples.Plataforma.Aplicacao;

namespace FaxpiBlogSimples.Nucleo.Compartilhado.Aplicacao
{
  public class RespostaBasica : IResposta
  {
    public string Mensagem { get; init; }
    public bool Sucesso { get; init; }

    public RespostaBasica(bool sucesso, string mensagem)
    {
      Sucesso = sucesso;
      Mensagem = mensagem;
    }
  }
}