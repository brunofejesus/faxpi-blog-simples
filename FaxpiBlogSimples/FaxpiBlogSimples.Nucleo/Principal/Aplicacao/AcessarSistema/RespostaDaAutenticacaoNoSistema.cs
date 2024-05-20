using FaxpiBlogSimples.Nucleo.Compartilhado.Aplicacao;

namespace FaxpiBlogSimples.Nucleo.Principal.Aplicacao.AcessarSistema
{
  public class RespostaDaAutenticacaoNoSistema : RespostaBasica
  {
    public int Identificador { get; set; }
    public const string MensagemDeSucesso = "Acesso efetuado com sucesso";
    public const string MessagemDeUsuarioInvalido = "Nome de usuário ou senha inválido";

    public RespostaDaAutenticacaoNoSistema(bool sucesso, string mensagem) : base(sucesso, mensagem)
    {
    }

    private RespostaDaAutenticacaoNoSistema(bool sucesso, string mensagem, int identificador) : base(sucesso, mensagem)
    {
      Identificador = identificador;
    }

    public static RespostaDaAutenticacaoNoSistema AcessoAutorizado(int identificador)
    {
      return new RespostaDaAutenticacaoNoSistema(true, MensagemDeSucesso, identificador);
    }

    public static RespostaDaAutenticacaoNoSistema UsuarioInvalido()
    {
      return new RespostaDaAutenticacaoNoSistema(false, MessagemDeUsuarioInvalido);
    }
  }
}