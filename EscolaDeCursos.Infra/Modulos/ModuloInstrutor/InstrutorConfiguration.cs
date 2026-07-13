using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EscolaDeCursos.Dominio.Modulos.ModuloInstrutor;

namespace EscolaDeCursos.Infra.Orm.Modulos.ModuloInstrutor;

public class InstrutorConfiguration : IEntityTypeConfiguration<Instrutor>
{
    public void Configure(EntityTypeBuilder<Instrutor> builder)
    {
        builder.ToTable("TBInstrutor");

        builder.HasKey(i => i.Id)
            .HasName("PK_TBInstrutor");

        builder.Property(i => i.Id)
            .ValueGeneratedNever();

        builder.Property(i => i.Nome)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnType("nvarchar(100)");

        builder.Property(i => i.Telefone)
            .IsRequired()
            .HasMaxLength(15)
            .HasColumnType("nvarchar(15)");

        builder.Property(i => i.Email)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnType("nvarchar(100)");

        builder.HasIndex(i => i.Email)
            .IsUnique()
            .HasDatabaseName("UQ_TBInstrutor_Email");
    }
}   
