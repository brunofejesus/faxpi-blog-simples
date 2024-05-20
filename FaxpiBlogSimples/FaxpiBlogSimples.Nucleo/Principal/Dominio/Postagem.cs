using FaxpiBlogSimples.Nucleo.Compartilhado.Dominio;

namespace FaxpiBlogSimples.Nucleo.Principal.Dominio
{
  public class Postagem : Entidade<int>
  {
    public string Titulo { get; set; }
    public string Conteudo { get; set; }
    public int UsuarioId { get; set; }
    public DateTime DataDaCriacao { get; set; }

    public Postagem(string titulo, string conteudo, int usuarioId)
    {
      Titulo = titulo;
      Conteudo = conteudo;
      UsuarioId = usuarioId;
      DataDaCriacao = DateTime.UtcNow;
    }
  }
}