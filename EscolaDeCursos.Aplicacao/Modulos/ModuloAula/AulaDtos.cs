namespace EscolaDeCursos.Aplicacao.Modulos.ModuloAula;

// ADICIONADO: "int Duracao" no DTO de listagem
public record ListarAulaDto(Guid Id, string Titulo, int Ordem, int Duracao, Guid CursoId);

public record CadastrarAulaDto(string Titulo, int Ordem, int Duracao, Guid CursoId);

public record EditarAulaDto(Guid Id, string Titulo, int Ordem, int Duracao, Guid CursoId);

public record DetalhesAulaDto(Guid Id, string Titulo, int Ordem, int Duracao, Guid CursoId);
