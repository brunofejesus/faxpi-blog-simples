using FaxpiBlogSimples.Plataforma.Compartilhado;

using FluentValidation;

using System.Globalization;

namespace FaxpiBlogSimples.Nucleo.Compartilhado
{
  public abstract class Validador<T> : AbstractValidator<T>, IValidador<T>
  {
    private readonly List<KeyValuePair<string, string>> _erros = [];
    public IReadOnlyCollection<KeyValuePair<string, string>> Erros => [.. _erros];

    private bool _valido;
    public bool Valido => _valido;

    static Validador()
    {
      TornarBrasileiro();
    }

    public static void TornarBrasileiro()
    {
      ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");
    }

    public bool Validar(T objeto)
    {
      var resultado = base.Validate(objeto);

      AtualizarValidade(resultado.IsValid);
      AdicionarErro(
        resultado.Errors
          .Select(erro => new KeyValuePair<string, string>(erro.ErrorCode, erro.ErrorMessage)
        )
      );

      return resultado.IsValid;
    }

    protected void AdicionarErro(KeyValuePair<string, string> erro)
    {
      _erros.Clear();
      _erros.Add(erro);
    }

    protected void AdicionarErro(IEnumerable<KeyValuePair<string, string>> erros)
    {
      _erros.Clear();
      _erros.AddRange(erros);
    }

    protected void AtualizarValidade(bool valido)
    {
      _valido = valido;
    }
  }
}