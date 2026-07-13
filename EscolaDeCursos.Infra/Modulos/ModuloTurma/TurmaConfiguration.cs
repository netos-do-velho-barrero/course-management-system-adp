using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EscolaDeCursos.Dominio.Modulos.ModuloTurma;

namespace EscolaDeCursos.Infra.Orm.Modulos.ModuloTurma;

public class TurmaConfiguration : IEntityTypeConfiguration<Turma>
{
    public void Configure(EntityTypeBuilder<Turma> builder)
    {
        builder.ToTable("TBTurma");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .ValueGeneratedNever();

        builder.Property(t => t.CursoId)
            .IsRequired();

        builder.Property(t => t.InstrutorId)
            .IsRequired();

        builder.Property(t => t.DataInicio)
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(t => t.DataTermino)
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(t => t.NumeroMaximoAlunos)
            .IsRequired();
    }
}
