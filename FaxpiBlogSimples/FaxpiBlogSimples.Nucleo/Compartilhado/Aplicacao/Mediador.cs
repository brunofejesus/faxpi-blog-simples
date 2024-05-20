using FaxpiBlogSimples.Nucleo.Compartilhado.Dominio.Excecoes;
using FaxpiBlogSimples.Plataforma.Aplicacao;
using FaxpiBlogSimples.Plataforma.Compartilhado;
using FaxpiBlogSimples.Plataforma.Dominio;

using Microsoft.Extensions.DependencyInjection;

namespace FaxpiBlogSimples.Nucleo.Compartilhado.Aplicacao
{
  public class Mediador : IMediador
  {
    private readonly IServiceProvider _container;

    public Mediador(IServiceProvider container)
    {
      _container = container;
    }

    public TResposta Enviar<TComando, TResposta>(TComando comando)
      where TComando : IComando
      where TResposta : IResposta
    {
      try
      {
        IValidador<TComando>? validador = _container.GetService<IValidador<TComando>>();

        if (validador != null && !validador.Validar(comando))
        {
          throw new ValidacaoException(string.Join(", ", validador.Erros.Select(erro => erro.Value)));
        }

        IExecutor<TComando, TResposta>? executor = _container.GetService<IExecutor<TComando, TResposta>>();

        if (executor != null)
        {
          TResposta resposta = executor.Executar(comando);

          return resposta;
        }
        else
        {
          throw new Exception("Executor não registrado.");
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    public void Notificar<TNotificacao>(TNotificacao notificacao) where TNotificacao : INotificacao
    {
      try
      {
        IEnumerable<INotificador<TNotificacao>>? notificadores = _container.GetService<IEnumerable<INotificador<TNotificacao>>>();

        if (notificadores != null)
        {
          foreach (INotificador<TNotificacao> notificador in notificadores)
          {
            notificador.Notificar(notificacao);
          }
        }
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}