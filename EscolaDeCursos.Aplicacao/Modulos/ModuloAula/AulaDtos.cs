namespace EscolaDeCursos.Aplicacao.Modulos.ModuloAula;

public record ListarAulaDto(Guid Id, string Titulo, int Ordem, Guid CursoId);

public record CadastrarAulaDto(string Titulo, int Ordem, int Duracao, Guid CursoId);

public record EditarAulaDto(Guid Id, string Titulo, int Ordem, int Duracao, Guid CursoId);

public record DetalhesAulaDto(Guid Id, string Titulo, int Ordem, int Duracao, Guid CursoId);
