using FaxpiBlogSimples.Plataforma.Dominio;

using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

namespace FaxpiBlogSimples.Nucleo.Compartilhado.Infraestrutura.Repositorios
{
  public class RepositorioBase<TContexto> : IRepositorioBase where TContexto : DbContext
  {
    protected TContexto Contexto { get; private set; }

    public RepositorioBase(TContexto contexto)
    {
      Contexto = contexto;
    }

    #region Consulta

    protected IEnumerable<T> Listar<T>(Expression<Func<T, bool>> predicate) where T : class, IEntidade
    {
      return [.. Contexto.Set<T>().Where(predicate).AsNoTracking()];
    }

    protected IEnumerable<T> Listar<T>() where T : class, IEntidade
    {
      return [.. Contexto.Set<T>().AsNoTracking()];
    }

    protected T? Obter<T>(Expression<Func<T, bool>> predicate) where T : class, IEntidade
    {
      return Contexto.Set<T>().AsNoTracking().FirstOrDefault(predicate);
    }

    protected T? ObterComSql<T>(string sql) where T : class, IEntidade
    {
      return Contexto.Set<T>().FromSqlRaw(sql).AsNoTracking().FirstOrDefault();
    }

    protected IEnumerable<T> ObterViewComSql<T>(string sql) where T : class
    {
      return [.. Contexto.Set<T>().FromSqlRaw(sql).AsNoTracking()];
    }

    #endregion Consulta

    #region Inserir

    protected void Inserir<T>(T entidade) where T : class, IEntidade
    {
      Contexto.Set<T>().Add(entidade);
    }

    protected void Inserir<T>(IEnumerable<T> entidades) where T : class, IEntidade
    {
      Contexto.Set<T>().AddRange(entidades);
    }

    #endregion Inserir

    #region Atualizar

    protected void Atualizar<T>(T entidade) where T : class, IEntidade
    {
      Contexto.Set<T>().Update(entidade);
    }

    protected void Atualizar<T>(IEnumerable<T> entidades) where T : class, IEntidade
    {
      Contexto.Set<T>().UpdateRange(entidades);
    }

    #endregion Atualizar

    #region Apagar

    protected void Apagar<T>(T entidade) where T : class, IEntidade
    {
      Contexto.Set<T>().Remove(entidade);
    }

    protected void Apagar<T>(IEnumerable<T> entidades) where T : class, IEntidade
    {
      Contexto.Set<T>().RemoveRange(entidades);
    }

    protected void Apagar<T>(Expression<Func<T, bool>> predicado) where T : class, IEntidade
    {
      Contexto.Set<T>().RemoveRange(Contexto.Set<T>().Where(predicado));
    }

    #endregion Apagar
  }
}