using FaxpiBlogSimples.Nucleo.Principal.Dominio;
using FaxpiBlogSimples.Nucleo.Principal.Infraestrutura.Repositorios;
using FaxpiBlogSimples.Nucleo.Principal.Infraestrutura.Servicos;
using FaxpiBlogSimples.Plataforma.Aplicacao;

namespace FaxpiBlogSimples.Nucleo.Principal.Aplicacao.RegistrarUsuario
{
  public class ExecutorDeRegistrarUsuario : IExecutor<ComandoDeRegistrarUsuario, RespostaDoRegistroDoUsuario>
  {
    private readonly IRepositorioDeUsuario _repositorioDeUsuario;
    private readonly IManipuladorDeSenha _manipuladorDeSenha;
    private readonly IUnidadeDeTrabalhoPrincipal _unidadeDeTrabalhoPrincipal;

    public ExecutorDeRegistrarUsuario(
      IRepositorioDeUsuario repositorioDeUsuario,
      IManipuladorDeSenha manipuladorDeSenha,
      IUnidadeDeTrabalhoPrincipal unidadeDeTrabalhoPrincipal)
    {
      _repositorioDeUsuario = repositorioDeUsuario;
      _manipuladorDeSenha = manipuladorDeSenha;
      _unidadeDeTrabalhoPrincipal = unidadeDeTrabalhoPrincipal;
    }

    public RespostaDoRegistroDoUsuario Executar(ComandoDeRegistrarUsuario comando)
    {
      Usuario? usuario = _repositorioDeUsuario.Obter(u => u.NomeDeUsuario == comando.Email);
      if (usuario is not null)
      {
        return RespostaDoRegistroDoUsuario.SucessoUsuarioJaRegistrado();
      }

      usuario = new Usuario(
        nome: comando.Nome!,
        nomeDeUsuario: comando.Email!,
        email: comando.Email!
      );

      string senhaEmbaralhada = _manipuladorDeSenha.GerarHash(comando.Senha!);
      usuario.AtualizarSenha(senhaEmbaralhada);

      _repositorioDeUsuario.RegistrarUsuario(usuario);

      _unidadeDeTrabalhoPrincipal.Salvar();

      return RespostaDoRegistroDoUsuario.DeSucesso();
    }
  }
}