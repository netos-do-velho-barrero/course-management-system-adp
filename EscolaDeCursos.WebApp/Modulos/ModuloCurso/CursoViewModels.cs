using System.ComponentModel.DataAnnotations;
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
    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo \"Nome\" deve conter entre 3 e 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Descrição\" deve ser preenchido.")]
    string Descricao,

    [Required(ErrorMessage = "O campo \"Carga Horária\" deve ser preenchido.")]
    [Range(1, int.MaxValue, ErrorMessage = "A carga horária deve ser maior que zero.")]
    int CargaHoraria,

    [Required(ErrorMessage = "O campo \"Nível\" deve ser preenchido.")]
    NivelCurso Nivel,

    [Required(ErrorMessage = "A categoria deve ser selecionada.")]
    Guid CategoriaId
);

public record EditarCursoViewModel(
    Guid Id,

    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo \"Nome\" deve conter entre 3 e 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Descrição\" deve ser preenchido.")]
    string Descricao,

    [Required(ErrorMessage = "O campo \"Carga Horária\" deve ser preenchido.")]
    [Range(1, int.MaxValue, ErrorMessage = "A carga horária deve ser maior que zero.")]
    int CargaHoraria,

    [Required(ErrorMessage = "O campo \"Nível\" deve ser preenchido.")]
    NivelCurso Nivel,

    [Required(ErrorMessage = "A categoria deve ser selecionada.")]
    Guid CategoriaId
);

public record ExcluirCursoViewModel(
    Guid Id,
    string Nome
);
