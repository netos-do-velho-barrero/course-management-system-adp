using System.ComponentModel.DataAnnotations;
using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;

namespace EscolaDeCursos.WebApp.Modulos.ModuloMatricula;

public record ListarMatriculaViewModel
{
    public Guid Id { get; set; }
    public Guid AlunoId { get; set; }
    public Guid TurmaId { get; set; }
    public DateTime DataMatricula { get; set; }
    public SituacaoMatricula Situacao { get; set; }
}

public record CadastrarMatriculaViewModel
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo \"Aluno\" é obrigatório.")]
    public Guid? AlunoId { get; set; }

    [Required(ErrorMessage = "O campo \"Turma\" é obrigatório.")]
    public Guid? TurmaId { get; set; }

    [Required(ErrorMessage = "O campo \"Situação\" é obrigatório.")]
    public SituacaoMatricula Situacao { get; set; } = SituacaoMatricula.Ativa;
}
public record EditarMatriculaViewModel
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo \"Situação\" é obrigatório.")]
    public SituacaoMatricula Situacao { get; set; }
}

public record ExcluirMatriculaViewModel
{
    public Guid Id { get; set; }
    public Guid AlunoId { get; set; }
    public Guid TurmaId { get; set; }
    public DateTime DataMatricula { get; set; }
    public SituacaoMatricula Situacao { get; set; }
}
