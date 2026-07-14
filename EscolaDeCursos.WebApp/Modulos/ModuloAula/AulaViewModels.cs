using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EscolaDeCursos.WebApp.Modulos.ModuloAula;

public record ListarAulaViewModel
{
    public Guid Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public int Ordem { get; set; }
    public int Duracao { get; set; }
    public string CursoNome { get; set; } = string.Empty;
    public Guid CursoId { get; set; }
}

public record CadastrarAulaViewModel
{
    [Required(ErrorMessage = "O campo \"Título\" deve ser preenchido.")]
    [StringLength(150, MinimumLength = 3, ErrorMessage = "O campo \"Título\" deve conter entre 3 e 150 caracteres.")]
    public string? Titulo { get; set; }

    [Required(ErrorMessage = "O campo \"Ordem\" deve ser preenchido.")]
    [Range(1, int.MaxValue, ErrorMessage = "O campo \"Ordem\" deve ser um número maior que zero.")]
    public int? Ordem { get; set; }

    [Required(ErrorMessage = "O campo \"Duração\" deve ser preenchido.")]
    [Range(1, int.MaxValue, ErrorMessage = "A duração da aula deve ser maior que zero minutos.")]
    public int? Duracao { get; set; }

    [Required(ErrorMessage = "A aula deve pertencer a um curso.")]
    public Guid? CursoId { get; set; }

    public List<SelectListItem>? Cursos { get; set; }
}

public record EditarAulaViewModel
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo \"Título\" deve ser preenchido.")]
    [StringLength(150, MinimumLength = 3, ErrorMessage = "O campo \"Título\" deve conter entre 3 e 150 caracteres.")]
    public string? Titulo { get; set; }

    [Required(ErrorMessage = "O campo \"Ordem\" deve ser preenchido.")]
    [Range(1, int.MaxValue, ErrorMessage = "O campo \"Ordem\" deve ser um número maior que zero.")]
    public int? Ordem { get; set; }

    [Required(ErrorMessage = "O campo \"Duração\" deve ser preenchido.")]
    [Range(1, int.MaxValue, ErrorMessage = "A duração da aula deve ser maior que zero minutos.")]
    public int? Duracao { get; set; }

    [Required(ErrorMessage = "A aula deve pertencer a um curso.")]
    public Guid? CursoId { get; set; }

    public List<SelectListItem>? Cursos { get; set; }
}

public record ExcluirAulaViewModel
{
    public Guid Id { get; set; }
    public string? Titulo { get; set; }
    public int Ordem { get; set; }
    public int Duracao { get; set; }
    public Guid CursoId { get; set; }
}
