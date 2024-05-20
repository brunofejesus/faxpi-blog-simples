using FaxpiBlogSimples.Nucleo.Principal.Infraestrutura.Repositorios;
using FaxpiBlogSimples.Plataforma.Aplicacao;

namespace FaxpiBlogSimples.Nucleo.Principal.Aplicacao.Blog.EditarPostagem
{
  public class ExecutorDeEditarPostagem : IExecutor<ComandoDeEditarPostagem, RespostaDeEditarPostagem>
  {
    private readonly IRepositorioDePostagem _repositorioDePostagem;
    private readonly IUnidadeDeTrabalhoPrincipal _unidadeDeTrabalhoPrincipal;

    public ExecutorDeEditarPostagem(IRepositorioDePostagem repositorioDePostagem, IUnidadeDeTrabalhoPrincipal unidadeDeTrabalhoPrincipal)
    {
      _repositorioDePostagem = repositorioDePostagem;
      _unidadeDeTrabalhoPrincipal = unidadeDeTrabalhoPrincipal;
    }

    public RespostaDeEditarPostagem Executar(ComandoDeEditarPostagem comando)
    {
      var postagem = _repositorioDePostagem.Obter(p => p.Id == comando.PostagemId && p.UsuarioId == comando.UsuarioLogado);

      if (postagem is null)
      {
        return RespostaDeEditarPostagem.DeNaoEncontrada();
      }

      postagem.Titulo = comando.Titulo!;
      postagem.Conteudo = comando.Conteudo!;

      _repositorioDePostagem.Atualizar(postagem);

      _unidadeDeTrabalhoPrincipal.Salvar();

      return RespostaDeEditarPostagem.DeSucesso();
    }
  }
}