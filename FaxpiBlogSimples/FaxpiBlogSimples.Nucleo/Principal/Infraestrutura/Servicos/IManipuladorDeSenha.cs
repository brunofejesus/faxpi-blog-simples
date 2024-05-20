namespace FaxpiBlogSimples.Nucleo.Principal.Infraestrutura.Servicos
{
  public interface IManipuladorDeSenha
  {
    string GerarHash(string senha);

    bool Validar(string senha, string senhaEmbaralhada);
  }
}