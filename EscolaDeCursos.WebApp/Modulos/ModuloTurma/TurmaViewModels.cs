using System.ComponentModel.DataAnnotations;

namespace EscolaDeCursos.WebApp.Modulos.ModuloTurma;

public record ListarTurmaViewModel
{
    public Guid Id { get; set; }
    public Guid CursoId { get; set; }
    public string Curso { get; set; } = string.Empty;
    public Guid InstrutorId { get; set; }
    public string Instrutor { get; set; } = string.Empty;
    public DateTime DataInicio { get; set; }
    public DateTime DataTermino { get; set; }
    public int NumeroMaximoAlunos { get; set; }
    public int QuantidadeAlunos { get; set; } // Propriedade adicionada
}

public record CadastrarTurmaViewModel
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo \"Curso\" é obrigatório.")]
    public Guid? CursoId { get; set; }

    [Required(ErrorMessage = "O campo \"Instrutor\" é obrigatório.")]
    public Guid? InstrutorId { get; set; }

    [Required(ErrorMessage = "O campo \"Data de Início\" é obrigatório.")]
    [DataType(DataType.Date)]
    public DateTime DataInicio { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "O campo \"Data de Término\" é obrigatório.")]
    [DataType(DataType.Date)]
    public DateTime DataTermino { get; set; } = DateTime.Today.AddMonths(1);

    [Required(ErrorMessage = "O campo \"Número Máximo de Alunos\" é obrigatório.")]
    [Range(1, int.MaxValue, ErrorMessage = "O número máximo de alunos deve ser maior que zero.")]
    public int NumeroMaximoAlunos { get; set; }
}

public record EditarTurmaViewModel
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo \"Curso\" é obrigatório.")]
    public Guid? CursoId { get; set; }

    [Required(ErrorMessage = "O campo \"Instrutor\" é obrigatório.")]
    public Guid? InstrutorId { get; set; }

    [Required(ErrorMessage = "O campo \"Data de Início\" é obrigatório.")]
    [DataType(DataType.Date)]
    public DateTime DataInicio { get; set; }

    [Required(ErrorMessage = "O campo \"Data de Término\" é obrigatório.")]
    [DataType(DataType.Date)]
    public DateTime DataTermino { get; set; }

    [Required(ErrorMessage = "O campo \"Número Máximo de Alunos\" é obrigatório.")]
    [Range(1, int.MaxValue, ErrorMessage = "O número máximo de alunos deve ser maior que zero.")]
    public int NumeroMaximoAlunos { get; set; }
}

public record ExcluirTurmaViewModel
{
    public Guid Id { get; set; }
    public string Curso { get; set; } = string.Empty;
    public string Instrutor { get; set; } = string.Empty;
    public DateTime DataInicio { get; set; }
    public DateTime DataTermino { get; set; }
    public int NumeroMaximoAlunos { get; set; }
}
