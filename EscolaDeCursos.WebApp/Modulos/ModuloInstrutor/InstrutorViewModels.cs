using System.ComponentModel.DataAnnotations;

namespace EscolaDeCursos.WebApp.Modulos.ModuloInstrutor;

public record ListarInstrutorViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public record CadastrarInstrutorViewModel
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo \"Nome\" é obrigatório.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo \"Nome\" deve conter entre 3 e 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo \"Telefone\" é obrigatório.")]
    public string Telefone { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo \"E-mail\" é obrigatório.")]
    [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
    public string Email { get; set; } = string.Empty;
}

public record EditarInstrutorViewModel
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo \"Nome\" é obrigatório.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo \"Nome\" deve conter entre 3 e 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo \"Telefone\" é obrigatório.")]
    public string Telefone { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo \"E-mail\" é obrigatório.")]
    [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
    public string Email { get; set; } = string.Empty;
}

public record ExcluirInstrutorViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
