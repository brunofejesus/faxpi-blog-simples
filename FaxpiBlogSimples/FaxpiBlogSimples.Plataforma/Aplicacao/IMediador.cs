using FaxpiBlogSimples.Plataforma.Dominio;

namespace FaxpiBlogSimples.Plataforma.Aplicacao
{
  public interface IMediador
  {
    TResposta Enviar<TComando, TResposta>(TComando comando) where TComando : IComando where TResposta : IResposta;

    void Notificar<TNotificacao>(TNotificacao notificacao) where TNotificacao : INotificacao;
  }
}