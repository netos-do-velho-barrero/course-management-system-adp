using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;

namespace EscolaDeCursos.Infra.Orm.Modulos.ModuloMatricula;

public class MatriculaConfiguration : IEntityTypeConfiguration<Matricula>
{
    public void Configure(EntityTypeBuilder<Matricula> builder)
    {
        builder.ToTable("TBMatricula");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedNever();

        builder.Property(m => m.AlunoId)
            .IsRequired();

        builder.Property(m => m.TurmaId)
            .IsRequired();

        builder.Property(m => m.DataMatricula)
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(m => m.Situacao)
            .IsRequired()
            .HasConversion<int>();
    }
}
