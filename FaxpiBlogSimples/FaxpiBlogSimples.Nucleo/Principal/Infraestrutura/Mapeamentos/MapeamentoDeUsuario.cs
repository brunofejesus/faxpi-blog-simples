using FaxpiBlogSimples.Nucleo.Principal.Dominio;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FaxpiBlogSimples.Nucleo.Principal.Infraestrutura.Mapeamentos
{
  public class MapeamentoDeUsuario : IEntityTypeConfiguration<Usuario>
  {
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
      builder.ToTable("usuario");

      builder.HasKey(x => x.Id);

      builder.Property(x => x.Id)
        .HasColumnName("usuario_id")
        .UseIdentityAlwaysColumn();

      builder.Property(x => x.NomeDeUsuario)
        .HasColumnName("usuario_lg")
        .HasMaxLength(255)
        .IsRequired();

      builder.Property(x => x.Senha)
        .HasColumnName("usuario_sh");

      builder.Property(x => x.Ativo)
        .HasColumnName("usuario_flg_ativo")
        .IsRequired();

      builder.Property(x => x.Email)
        .HasMaxLength(255)
        .HasColumnName("usuario_ee_email")
        .IsRequired();
    }
  }
}