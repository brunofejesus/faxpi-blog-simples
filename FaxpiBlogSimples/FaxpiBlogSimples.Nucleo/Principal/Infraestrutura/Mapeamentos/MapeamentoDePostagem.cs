using FaxpiBlogSimples.Nucleo.Principal.Dominio;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FaxpiBlogSimples.Nucleo.Principal.Infraestrutura.Mapeamentos
{
  public class MapeamentoDePostagem : IEntityTypeConfiguration<Postagem>
  {
    public void Configure(EntityTypeBuilder<Postagem> builder)
    {
      builder.ToTable("postagem");

      builder.HasKey(x => x.Id);

      builder.Property(x => x.Id)
        .HasColumnName("postagem_id")
        .UseIdentityAlwaysColumn();

      builder.Property(x => x.UsuarioId)
        .HasColumnName("postagem_usuario_id");

      builder.Property(x => x.Titulo)
        .HasMaxLength(100)
        .HasColumnName("postagem_titulo");

      builder.Property(x => x.Conteudo)
        .HasMaxLength(1000)
        .HasColumnName("postagem_conteudo");

      builder.Property(x => x.DataDaCriacao)
        .HasDefaultValueSql("now()")
        .HasColumnName("postagem_data_criacao");
    }
  }
}