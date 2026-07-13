using FluentResults;
using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloCategoria;

public class ServicoCategoria : ServicoBase<Categoria>
{
    private readonly IRepositorioCategoria repositorioCategoria;

    public ServicoCategoria(IRepositorioCategoria repositorioCategoria)
    {
        this.repositorioCategoria = repositorioCategoria;
    }

    public Result Cadastrar(CadastrarCategoriaDto dto)
    {
        if (repositorioCategoria.ExisteNome(dto.Nome))
            return Falha(nameof(dto.Nome), "Já existe uma categoria cadastrada com esse nome.");

        Categoria categoria = new Categoria(dto.Nome);

        Result resultadoValidacao = ValidarEntidade(categoria);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioCategoria.Cadastrar(categoria);

        return Result.Ok();
    }

    public Result Editar(EditarCategoriaDto dto)
    {
        if (repositorioCategoria.ExisteNome(dto.Nome, dto.Id))
            return Falha(nameof(dto.Nome), "Já existe uma categoria cadastrada com esse nome.");

        Categoria categoria = new Categoria(dto.Nome);

        Result resultadoValidacao = ValidarEntidade(categoria);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        bool conseguiuEditar = repositorioCategoria.Editar(dto.Id, categoria);

        if (!conseguiuEditar)
            return Result.Fail("Categoria não encontrada.");

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        bool conseguiuExcluir = repositorioCategoria.Excluir(id);

        if (!conseguiuExcluir)
            return Result.Fail("Categoria não encontrada.");

        return Result.Ok();
    }

    public List<ListarCategoriaDto> SelecionarTodos()
    {
        return repositorioCategoria
            .SelecionarTodos()
            .Select(c => new ListarCategoriaDto(c.Id, c.Nome))
            .ToList();
    }

    public Result<DetalhesCategoriaDto> SelecionarPorId(Guid id)
    {
        Categoria? categoria = repositorioCategoria.SelecionarPorId(id);

        if (categoria == null)
            return Result.Fail("Categoria não encontrada.");

        return Result.Ok(new DetalhesCategoriaDto(
            categoria.Id,
            categoria.Nome
        ));
    }
}
