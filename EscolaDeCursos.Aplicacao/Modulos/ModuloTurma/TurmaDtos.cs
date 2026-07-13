namespace EscolaDeCursos.Aplicacao.Modulos.ModuloTurma;

public record CadastrarTurmaDto(Guid CursoId, Guid InstrutorId, DateTime DataInicio, DateTime DataTermino, int NumeroMaximoAlunos);

public record EditarTurmaDto(Guid Id, Guid CursoId, Guid InstrutorId, DateTime DataInicio, DateTime DataTermino, int NumeroMaximoAlunos);

public record ListarTurmaDto(Guid Id, Guid CursoId, Guid InstrutorId, DateTime DataInicio, DateTime DataTermino, int NumeroMaximoAlunos);

public record DetalhesTurmaDto(Guid Id, Guid CursoId, Guid InstrutorId, DateTime DataInicio, DateTime DataTermino, int NumeroMaximoAlunos);
