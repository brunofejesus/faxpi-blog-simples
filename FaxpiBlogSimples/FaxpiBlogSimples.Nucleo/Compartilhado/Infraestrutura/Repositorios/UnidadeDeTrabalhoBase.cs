using FaxpiBlogSimples.Plataforma.Infraestrutura;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace FaxpiBlogSimples.Nucleo.Compartilhado.Infraestrutura.Repositorios
{
  public abstract class UnidadeDeTrabalhoBase<TContext> : IUnidadeDeTrabalho where TContext : DbContext
  {
    protected TContext? Contexto { get; private set; }
    protected IDbContextTransaction? Transacao { get; private set; }

    protected UnidadeDeTrabalhoBase(TContext contexto)
    {
      Contexto = contexto;
    }

    public IDisposable CriarTransacao()
    {
#pragma warning disable CS8603 // Possible null reference return.
      return Transacao ??= Contexto?.Database.BeginTransaction();
#pragma warning restore CS8603 // Possible null reference return.
    }

    public void Descartar()
    {
      if (Transacao is not null)
      {
        Transacao.Rollback();
      }
    }

    public int Salvar(bool confirmarTransacao = true)
    {
      int resultado = Contexto?.SaveChanges() ?? 0;

      if (Transacao is not null && confirmarTransacao)
      {
        Transacao.Commit();
      }

      return resultado;
    }

    public void UsarTransacao(IDisposable transacao)
    {
      if (transacao is IDbContextTransaction)
      {
        Transacao = transacao as IDbContextTransaction;
        Contexto?.Database.UseTransaction(Transacao?.GetDbTransaction());
      }

      throw new InvalidCastException("Não é possível fazer uso de uma transação inválida.");
    }
  }
}