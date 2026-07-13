using EscolaDeCursos.Dominio.Modulos.ModuloAula;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaDeCursos.Infra.Modulos.ModuloAula;

public sealed class AulaConfiguration : IEntityTypeConfiguration<Aula>
{
    public void Configure(EntityTypeBuilder<Aula> builder)
    {
        builder.ToTable("TBAula");

        builder.HasKey(a => a.Id)
            .HasName("PK_TBAula");

        builder.Property(a => a.Id)
            .ValueGeneratedNever();

        builder.Property(a => a.Titulo)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(a => a.CursoId)
            .IsRequired();

        builder.Property(a => a.Ordem)
            .IsRequired();

        builder.Property(a => a.Duracao)
            .IsRequired();

        builder.HasIndex(a => new { a.CursoId, a.Ordem })
            .IsUnique()
            .HasDatabaseName("UQ_TBAula_CursoId_Ordem");
    }
}
