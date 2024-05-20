using FaxpiBlogSimples.Plataforma.Dominio;

namespace FaxpiBlogSimples.Plataforma.Aplicacao
{
  public interface INotificador<in TNotificacao> where TNotificacao : INotificacao
  {
    void Notificar(TNotificacao notificacao);
  }
}