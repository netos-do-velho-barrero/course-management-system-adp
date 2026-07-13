using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAgenda.WebApp.Compartilhado.Infra.Orm.Config;

public sealed class CursoConfiguration : IEntityTypeConfiguration<Curso>
{
    public void Configure(EntityTypeBuilder<Curso> builder)
    {
        builder.ToTable("TBCurso");

        builder.HasKey(c => c.Id)
            .HasName("PK_TBCurso");

        builder.Property(c => c.Id)
            .ValueGeneratedNever();

        builder.Property(c => c.Nome)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Descricao)
            .IsRequired();

        builder.Property(c => c.CargaHoraria)
            .IsRequired();

        builder.Property(c => c.Nivel)
            .IsRequired();

        builder.HasOne(c => c.Categoria)
            .WithMany(c => c.Cursos)
            .HasForeignKey(c => c.CategoriaId)
            .HasConstraintName("FK_TBCurso_TBCategoria")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
