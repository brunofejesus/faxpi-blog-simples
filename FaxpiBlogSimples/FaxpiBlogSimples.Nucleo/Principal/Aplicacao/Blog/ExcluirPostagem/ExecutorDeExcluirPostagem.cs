using FaxpiBlogSimples.Nucleo.Principal.Infraestrutura.Repositorios;
using FaxpiBlogSimples.Plataforma.Aplicacao;

namespace FaxpiBlogSimples.Nucleo.Principal.Aplicacao.Blog.ExcluirPostagem
{
  public class ExecutorDeExcluirPostagem : IExecutor<ComandoDeExcluirPostagem, RespostaDeExcluirPostagem>
  {
    private readonly IRepositorioDePostagem _repositorioDePostagem;
    private readonly IUnidadeDeTrabalhoPrincipal _unidadeDeTrabalho;

    public ExecutorDeExcluirPostagem(
      IRepositorioDePostagem repositorioDePostagem,
      IUnidadeDeTrabalhoPrincipal unidadeDeTrabalho)
    {
      _repositorioDePostagem = repositorioDePostagem;
      _unidadeDeTrabalho = unidadeDeTrabalho;
    }

    public RespostaDeExcluirPostagem Executar(ComandoDeExcluirPostagem comando)
    {
      var postagem = _repositorioDePostagem.Obter(p => p.Id == comando.PostagemId &&
      p.UsuarioId == comando.UsuarioLogado);

      if (postagem is null)
      {
        return RespostaDeExcluirPostagem.DeErro();
      }

      _repositorioDePostagem.Excluir(postagem);
      _unidadeDeTrabalho.Salvar();

      return RespostaDeExcluirPostagem.DeSucesso();
    }
  }
}