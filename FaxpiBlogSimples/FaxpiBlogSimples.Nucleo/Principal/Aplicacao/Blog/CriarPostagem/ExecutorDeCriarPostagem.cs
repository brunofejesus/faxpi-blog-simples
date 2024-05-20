using FaxpiBlogSimples.Nucleo.Principal.Dominio;
using FaxpiBlogSimples.Nucleo.Principal.Dominio.Notificacoes;
using FaxpiBlogSimples.Nucleo.Principal.Infraestrutura.Repositorios;
using FaxpiBlogSimples.Plataforma.Aplicacao;

namespace FaxpiBlogSimples.Nucleo.Principal.Aplicacao.Blog.CriarPostagem
{
  public class ExecutorDeCriarPostagem : IExecutor<ComandoDeCriarPostagem, RespostaDeCriarPostagem>
  {
    private readonly IRepositorioDePostagem _repositorioDePostagem;
    private readonly IUnidadeDeTrabalhoPrincipal _unidadeDeTrabalhoPrincipal;
    private readonly IMediador _mediador;

    public ExecutorDeCriarPostagem(
      IRepositorioDePostagem repositorioDePostagem,
      IUnidadeDeTrabalhoPrincipal unidadeDeTrabalhoPrincipal,
      IMediador mediador)
    {
      _repositorioDePostagem = repositorioDePostagem;
      _unidadeDeTrabalhoPrincipal = unidadeDeTrabalhoPrincipal;
      _mediador = mediador;
    }

    public RespostaDeCriarPostagem Executar(ComandoDeCriarPostagem comando)
    {
      var postagem = new Postagem(
        comando.Titulo,
      comando.Conteudo,
        comando.UsuarioLogado
      );

      _repositorioDePostagem.CriarPostagem(postagem);

      _unidadeDeTrabalhoPrincipal.Salvar();

      _mediador.Notificar(new NotificacaoDeNovaPostagem(
            $"Uma nova postagem foi feita no blog com título de - {comando.Titulo}"
          ));

      return RespostaDeCriarPostagem.DeSucesso();
    }
  }
}