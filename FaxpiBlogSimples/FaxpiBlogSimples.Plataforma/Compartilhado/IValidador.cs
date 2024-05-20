namespace FaxpiBlogSimples.Plataforma.Compartilhado
{
  public interface IValidador<in T>
  {
    IReadOnlyCollection<KeyValuePair<string, string>> Erros { get; }

    bool Validar(T objeto);
  }
}