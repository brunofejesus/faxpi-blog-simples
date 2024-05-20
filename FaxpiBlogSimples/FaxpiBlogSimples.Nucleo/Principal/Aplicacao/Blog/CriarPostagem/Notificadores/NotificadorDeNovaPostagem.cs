using FaxpiBlogSimples.Nucleo.Compartilhado.Infraestrutura.Servicos;
using FaxpiBlogSimples.Nucleo.Principal.Dominio.Notificacoes;
using FaxpiBlogSimples.Plataforma.Aplicacao;

namespace FaxpiBlogSimples.Nucleo.Principal.Aplicacao.Blog.CriarPostagem.Notificadores
{
  public class NotificadorDeNovaPostagem : INotificador<NotificacaoDeNovaPostagem>
  {
    private readonly BlogWebSocketManager _blogWebSocktManager;

    public NotificadorDeNovaPostagem(BlogWebSocketManager blogWebSocktManager)
    {
      _blogWebSocktManager = blogWebSocktManager;
    }

    public void Notificar(NotificacaoDeNovaPostagem notificacao)
    {
      _blogWebSocktManager.BroadcastMessageAsync(notificacao.Titulo!).GetAwaiter().GetResult();
    }
  }
}