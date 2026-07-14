namespace EscolaDeCursos.Aplicacao.Modulos.ModuloInstrutor;

public record CadastrarInstrutorDto(string Nome, string Telefone, string Email);

public record EditarInstrutorDto(Guid Id, string Nome, string Telefone, string Email);

public record ListarInstrutorDto(Guid Id, string Nome, string Telefone, string Email);

public record DetalhesInstrutorDto(Guid Id, string Nome, string Telefone, string Email);
