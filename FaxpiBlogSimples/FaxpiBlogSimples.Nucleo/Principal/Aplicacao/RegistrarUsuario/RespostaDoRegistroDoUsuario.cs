using FaxpiBlogSimples.Nucleo.Compartilhado.Aplicacao;

namespace FaxpiBlogSimples.Nucleo.Principal.Aplicacao.RegistrarUsuario
{
  public class RespostaDoRegistroDoUsuario : RespostaBasica
  {
    public const string MensagemDeSucesso = "Registro realizado com sucesso";
    public const string MensagemDeSucessoUsuarioJaRegistrado = "Usuario já registrado com esse e-mail";

    public RespostaDoRegistroDoUsuario(bool sucesso, string mensagem) : base(sucesso, mensagem)
    {
    }

    public static RespostaDoRegistroDoUsuario DeSucesso()
    {
      return new RespostaDoRegistroDoUsuario(true, MensagemDeSucesso);
    }

    public static RespostaDoRegistroDoUsuario SucessoUsuarioJaRegistrado()
    {
      return new RespostaDoRegistroDoUsuario(true, MensagemDeSucessoUsuarioJaRegistrado);
    }
  }
}