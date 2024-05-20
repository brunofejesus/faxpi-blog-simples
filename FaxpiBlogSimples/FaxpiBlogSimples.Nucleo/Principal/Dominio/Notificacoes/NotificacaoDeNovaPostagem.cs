using FaxpiBlogSimples.Plataforma.Dominio;

namespace FaxpiBlogSimples.Nucleo.Principal.Dominio.Notificacoes
{
  public class NotificacaoDeNovaPostagem : INotificacao
  {
    public string? Titulo { get; set; }

    public NotificacaoDeNovaPostagem(string? titulo)
    {
      Titulo = titulo;
    }
  }
}