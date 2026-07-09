
using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloMatricula;

public record CadastrarMatriculaDto(Guid AlunoId, Guid TurmaId);

public record ListarMatriculaDto(Guid Id, Guid AlunoId, Guid TurmaId, DateTime DataMatricula, SituacaoMatricula Situacao);

public record DetalhesMatriculaDto(Guid Id, Guid AlunoId, Guid TurmaId, DateTime DataMatricula, SituacaoMatricula Situacao);
