using FaxpiBlogSimples.Nucleo.Principal.Dominio;
using FaxpiBlogSimples.Nucleo.Principal.Infraestrutura.Repositorios;
using FaxpiBlogSimples.Nucleo.Principal.Infraestrutura.Servicos;
using FaxpiBlogSimples.Plataforma.Aplicacao;

namespace FaxpiBlogSimples.Nucleo.Principal.Aplicacao.AcessarSistema
{
  public class ExecutorDeAcessarSistema : IExecutor<ComandoAcessarSistema, RespostaDaAutenticacaoNoSistema>
  {
    private readonly IRepositorioDeUsuario _repositorioDeUsuario;
    private readonly IManipuladorDeSenha _manipuladorDeSenha;

    public ExecutorDeAcessarSistema(
      IRepositorioDeUsuario repositorioDeUsuario,
      IManipuladorDeSenha manipuladorDeSenha)
    {
      _repositorioDeUsuario = repositorioDeUsuario;
      _manipuladorDeSenha = manipuladorDeSenha;
    }

    public RespostaDaAutenticacaoNoSistema Executar(ComandoAcessarSistema comando)
    {
      try
      {
        Usuario? usuario = _repositorioDeUsuario.Obter(u => u.NomeDeUsuario == comando.NomeDeUsuario);
        if (usuario is not null)
        {
          bool usuarioAutenticado = _manipuladorDeSenha.Validar(comando.Senha!, usuario.Senha!);
          if (usuarioAutenticado)
          {
            return RespostaDaAutenticacaoNoSistema.AcessoAutorizado(usuario.Id);
          }
        }

        return RespostaDaAutenticacaoNoSistema.UsuarioInvalido();
      }
      catch
      {
        return RespostaDaAutenticacaoNoSistema.UsuarioInvalido();
      }
    }
  }
}