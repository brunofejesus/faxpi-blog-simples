using FaxpiBlogSimples.Nucleo.Acesso;
using FaxpiBlogSimples.Nucleo.Compartilhado.Aplicacao;
using FaxpiBlogSimples.Nucleo.Compartilhado.Infraestrutura.Servicos;
using FaxpiBlogSimples.Plataforma.Aplicacao;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FaxpiBlogSimples.Nucleo.Compartilhado
{
  public static class RegistradorDoNucleo
  {
    public static IServiceCollection AdicionarNucleo(this IServiceCollection servicos, IConfigurationRoot configuracoes)
    {
      servicos.AddScoped<IMediador, Mediador>();
      servicos.RegistrarModuloDeAcesso(configuracoes);
      servicos.AddSingleton<BlogWebSocketManager>();

      return servicos;
    }
  }
}