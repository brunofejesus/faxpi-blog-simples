namespace FaxpiBlogSimples.Plataforma.Aplicacao
{
  public interface IExecutor<in TComando, out TResposta> where TComando : IComando where TResposta : IResposta
  {
    TResposta Executar(TComando comando);
  }
}