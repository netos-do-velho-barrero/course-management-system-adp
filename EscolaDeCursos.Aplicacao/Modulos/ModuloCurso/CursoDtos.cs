using EscolaDeCursos.Dominio.Modulos.ModuloCurso;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;

public record ListarCursoDto(
    Guid Id,
    string Nome,
    string Descricao,
    int CargaHoraria,
    NivelCurso Nivel,
    Guid CategoriaId
);

public record CadastrarCursoDto(
    string Nome,
    string Descricao,
    int CargaHoraria,
    NivelCurso Nivel,
    Guid CategoriaId
);

public record EditarCursoDto(
    Guid Id,
    string Nome,
    string Descricao,
    int CargaHoraria,
    NivelCurso Nivel,
    Guid CategoriaId
);

public record DetalhesCursoDto(
    Guid Id,
    string Nome,
    string Descricao,
    int CargaHoraria,
    NivelCurso Nivel,
    Guid CategoriaId
);
