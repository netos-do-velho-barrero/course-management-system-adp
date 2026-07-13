using FluentResults;
using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloAula;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloAula;

public class ServicoAula : ServicoBase<Aula>
{
    private readonly IRepositorioAula repositorioAula;

    public ServicoAula(IRepositorioAula repositorioAula)
    {
        this.repositorioAula = repositorioAula;
    }

    public Result Cadastrar(CadastrarAulaDto dto)
    {
        if (repositorioAula.ExisteOrdemNoCurso(dto.Ordem, dto.CursoId))
            return Falha(nameof(dto.Ordem), "A ordem da aula dentro de um mesmo curso não pode se repetir.");

        Aula aula = new Aula(dto.Titulo, dto.CursoId, dto.Ordem, dto.Duracao);

        Result resultadoValidacao = ValidarEntidade(aula);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioAula.Cadastrar(aula);

        return Result.Ok();
    }

    public Result Editar(EditarAulaDto dto)
    {
        if (repositorioAula.ExisteOrdemNoCurso(dto.Ordem, dto.CursoId, dto.Id))
            return Falha(nameof(dto.Ordem), "A ordem da aula dentro de um mesmo curso não pode se repetir.");

        Aula aula = new Aula(dto.Titulo, dto.CursoId, dto.Ordem, dto.Duracao);

        Result resultadoValidacao = ValidarEntidade(aula);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        bool conseguiuEditar = repositorioAula.Editar(dto.Id, aula);

        if (!conseguiuEditar)
            return Result.Fail("Aula não encontrada.");

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        bool conseguiuExcluir = repositorioAula.Excluir(id);

        if (!conseguiuExcluir)
            return Result.Fail("Aula não encontrada.");

        return Result.Ok();
    }

    public List<ListarAulaDto> SelecionarTodos()
    {
        return repositorioAula
            .SelecionarTodos()
            .Select(a => new ListarAulaDto(a.Id, a.Titulo, a.Ordem, a.CursoId))
            .ToList();
    }

    public Result<DetalhesAulaDto> SelecionarPorId(Guid id)
    {
        Aula? aula = repositorioAula.SelecionarPorId(id);

        if (aula == null)
            return Result.Fail("Aula não encontrada.");

        return Result.Ok(new DetalhesAulaDto(
            aula.Id,
            aula.Titulo,
            aula.Ordem,
            aula.Duracao,
            aula.CursoId
        ));
    }
}
