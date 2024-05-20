using FaxpiBlogSimples.Nucleo.Principal.Aplicacao.AcessarSistema;
using FaxpiBlogSimples.Nucleo.Principal.Aplicacao.Blog.CriarPostagem;
using FaxpiBlogSimples.Nucleo.Principal.Aplicacao.Blog.CriarPostagem.Notificadores;
using FaxpiBlogSimples.Nucleo.Principal.Aplicacao.Blog.EditarPostagem;
using FaxpiBlogSimples.Nucleo.Principal.Aplicacao.Blog.ExcluirPostagem;
using FaxpiBlogSimples.Nucleo.Principal.Aplicacao.Blog.ObterPostagem;
using FaxpiBlogSimples.Nucleo.Principal.Aplicacao.RegistrarUsuario;
using FaxpiBlogSimples.Nucleo.Principal.Dominio.Notificacoes;
using FaxpiBlogSimples.Nucleo.Principal.Infraestrutura.Repositorios;
using FaxpiBlogSimples.Nucleo.Principal.Infraestrutura.Servicos;
using FaxpiBlogSimples.Plataforma.Aplicacao;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FaxpiBlogSimples.Nucleo.Acesso
{
  public static class RegistradorDoModuloPrincipal
  {
    private const string ChaveDaConfiguracaoDoBancoDeDados = "ConnectionStrings:DefaultConnection";

    internal static IServiceCollection RegistrarModuloDeAcesso(this IServiceCollection servicos, IConfigurationRoot configuracoes)
    {
      servicos
        .AddDbContextPool<ContextoDePrincipal>(opcoes => opcoes.UseNpgsql(configuracoes.GetValue<string>(ChaveDaConfiguracaoDoBancoDeDados)))
        .AddScoped<ContextoDePrincipal>()
        .AddScoped<IUnidadeDeTrabalhoPrincipal, UnidadeDeTrabalhoPrincipal>();

      servicos.AddScoped<IRepositorioDeUsuario, RepositorioDeUsuario>();
      servicos.AddScoped<IRepositorioDePostagem, RepositorioDePostagem>();
      servicos.AddScoped<IManipuladorDeSenha>(x => new ManipuladorDeSenhaProtegida());
      servicos.AddTransient<IExecutor<ComandoAcessarSistema, RespostaDaAutenticacaoNoSistema>, ExecutorDeAcessarSistema>();
      servicos.AddTransient<IExecutor<ComandoDeRegistrarUsuario, RespostaDoRegistroDoUsuario>, ExecutorDeRegistrarUsuario>();
      servicos.AddTransient<IExecutor<ComandoDeCriarPostagem, RespostaDeCriarPostagem>, ExecutorDeCriarPostagem>();
      servicos.AddTransient<INotificador<NotificacaoDeNovaPostagem>, NotificadorDeNovaPostagem>();
      servicos.AddTransient<IExecutor<ComandoDeEditarPostagem, RespostaDeEditarPostagem>, ExecutorDeEditarPostagem>();
      servicos.AddTransient<IExecutor<ComandoDeExcluirPostagem, RespostaDeExcluirPostagem>, ExecutorDeExcluirPostagem>();
      servicos.AddTransient<IExecutor<ComandoDeObterPostagem, RespostaDeObterPostagem>, ExecutorDeObterPostagem>();

      servicos
        .AddScoped<InicializadorDoContextoDePrincipal>();

      return servicos;
    }
  }
}