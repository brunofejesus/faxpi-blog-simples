using FaxpiBlogSimples.Nucleo.Compartilhado.Dominio;

namespace FaxpiBlogSimples.Nucleo.Principal.Dominio
{
  public class Usuario : Entidade<int>
  {
    public string Nome { get; set; }
    public string NomeDeUsuario { get; set; }
    public string? Email { get; set; }
    private string? _senha;
    public string? Senha { get => _senha; init => _senha = value; }

    public bool Ativo { get; init; }

    public Usuario(string nome, string nomeDeUsuario, string? email)
    {
      Nome = nome;
      NomeDeUsuario = nomeDeUsuario;
      Email = email;
      Ativo = true;
    }

    public void AtualizarSenha(string senha)
    {
      if (string.IsNullOrWhiteSpace(senha))
      {
        throw new ArgumentNullException(nameof(senha));
      }

      _senha = senha;
    }
  }
}