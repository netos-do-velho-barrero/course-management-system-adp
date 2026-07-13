using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCurso;

public record ListarCursosViewModel(
    Guid Id,
    string Nome,
    string Descricao,
    int CargaHoraria,
    NivelCurso Nivel,
    Guid CategoriaId
);

public record CadastrarCursoViewModel(
    [Required(ErrorMessage = "O campo Nome deve ser preenchido.")]
    [StringLength(100, MinimumLength = 3)]
    string Nome,

    [Required(ErrorMessage = "O campo Descrição deve ser preenchido.")]
    string Descricao,

    [Range(1, int.MaxValue, ErrorMessage = "A carga horária deve ser maior que zero.")]
    int CargaHoraria,

    [Range(0, 2, ErrorMessage = "Selecione um nível válido.")]
    NivelCurso Nivel,

    [Required(ErrorMessage = "A categoria deve ser selecionada.")]
    Guid? CategoriaId,

    // Alterado para ? e inicializado com Enumerable.Empty para o validador ignorar no POST
    IEnumerable<SelectListItem>? Categorias = null
);

public record EditarCursoViewModel(
    Guid Id,

    [Required(ErrorMessage = "O campo Nome deve ser preenchido.")]
    [StringLength(100, MinimumLength = 3)]
    string Nome,

    [Required(ErrorMessage = "O campo Descrição deve ser preenchido.")]
    string Descricao,

    [Range(1, int.MaxValue, ErrorMessage = "A carga horária deve ser maior que zero.")]
    int CargaHoraria,

    [Range(0, 2, ErrorMessage = "Selecione um nível válido.")]
    NivelCurso Nivel,

    [Required(ErrorMessage = "A categoria deve ser selecionada.")]
    Guid? CategoriaId,

    // Alterado para ? e inicializado com Enumerable.Empty para o validador ignorar no POST
    IEnumerable<SelectListItem>? Categorias = null
);

public record ExcluirCursoViewModel(
    Guid Id,
    string Nome
);
