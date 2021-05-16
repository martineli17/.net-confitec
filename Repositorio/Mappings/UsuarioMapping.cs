using Dominio.Entidades;
using Dominio.ValuesType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Repositorio.Mapeamento
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .HasColumnName("Id")
                   .HasColumnType("UNIQUEIDENTIFIER")
                   .IsRequired();
            builder.Property(x => x.Nome)
                   .HasColumnName("Nome")
                   .HasMaxLength(100)
                   .IsRequired();
            builder.Property(x => x.Sobrenome)
                   .HasColumnName("Sobrenome")
                   .HasMaxLength(100)
                   .IsRequired();
            builder.Property(x => x.Email)
                   .HasColumnName("Email")
                   .HasMaxLength(60)
                   .IsRequired();
            builder.Property(x => x.DataNascimento)
                   .HasColumnName("Datetime")
                   .IsRequired();
            builder.Property(x => x.Escolaridade)
                   .HasColumnName("Escolaridade")
                   .HasConversion(new EnumToNumberConverter<EnumEscolaridade, int>())
                   .IsRequired();
        }
    }
}
