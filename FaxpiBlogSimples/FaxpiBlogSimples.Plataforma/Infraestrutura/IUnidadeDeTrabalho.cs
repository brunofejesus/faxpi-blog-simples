namespace FaxpiBlogSimples.Plataforma.Infraestrutura
{
  public interface IUnidadeDeTrabalho
  {
    IDisposable CriarTransacao();

    void Descartar();

    int Salvar(bool confirmarTransacao = true);

    void UsarTransacao(IDisposable transacao);
  }
}