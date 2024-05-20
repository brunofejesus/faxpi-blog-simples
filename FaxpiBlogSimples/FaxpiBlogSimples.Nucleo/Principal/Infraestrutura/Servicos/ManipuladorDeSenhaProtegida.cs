namespace FaxpiBlogSimples.Nucleo.Principal.Infraestrutura.Servicos
{
  public class ManipuladorDeSenhaProtegida : IManipuladorDeSenha
  {
    public string GerarHash(string senha) => BCrypt.Net.BCrypt.EnhancedHashPassword(senha);

    public bool Validar(string senha, string senhaEmbaralhada) => BCrypt.Net.BCrypt.EnhancedVerify(senha, senhaEmbaralhada);
  }
}