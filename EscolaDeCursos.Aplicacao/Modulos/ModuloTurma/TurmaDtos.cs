namespace EscolaDeCursos.Aplicacao.Modulos.ModuloTurma;

public record CadastrarTurmaDto(Guid CursoId, Guid InstrutorId, DateTime DataInicio, DateTime DataTermino, int NumeroMaximoAlunos);

public record EditarTurmaDto(Guid Id, Guid CursoId, Guid InstrutorId, DateTime DataInicio, DateTime DataTermino, int NumeroMaximoAlunos);

// Propriedade QuantidadeAlunos adicionada nos dois records abaixo
public record ListarTurmaDto(Guid Id, Guid CursoId, string Curso, Guid InstrutorId, string Instrutor, DateTime DataInicio, DateTime DataTermino, int NumeroMaximoAlunos, int QuantidadeAlunos);

public record DetalhesTurmaDto(Guid Id, Guid CursoId, string Curso, Guid InstrutorId, string Instrutor, DateTime DataInicio, DateTime DataTermino, int NumeroMaximoAlunos, int QuantidadeAlunos);
