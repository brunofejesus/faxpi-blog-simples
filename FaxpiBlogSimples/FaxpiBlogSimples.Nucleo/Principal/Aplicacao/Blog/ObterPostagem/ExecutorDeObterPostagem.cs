using FaxpiBlogSimples.Nucleo.Principal.Infraestrutura.Repositorios;
using FaxpiBlogSimples.Nucleo.Principal.Infraestrutura.Repositorios.Filtros;
using FaxpiBlogSimples.Plataforma.Aplicacao;

namespace FaxpiBlogSimples.Nucleo.Principal.Aplicacao.Blog.ObterPostagem
{
  public class ExecutorDeObterPostagem : IExecutor<ComandoDeObterPostagem, RespostaDeObterPostagem>
  {
    private readonly IRepositorioDePostagem _repositorioDePostagem;

    public ExecutorDeObterPostagem(IRepositorioDePostagem repositorioDePostagem)
    {
      _repositorioDePostagem = repositorioDePostagem;
    }

    public RespostaDeObterPostagem Executar(ComandoDeObterPostagem comando)
    {
      var lista = _repositorioDePostagem.Listar(FiltroDePostagem.PorUsuarioPostagemId(
        comando.PostagemId, comando.CodigoDoUsuario));

      return RespostaDeObterPostagem.DeSucesso(lista);
    }
  }
}