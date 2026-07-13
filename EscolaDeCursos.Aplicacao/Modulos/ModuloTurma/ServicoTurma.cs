using FluentResults;
using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloTurma;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloTurma;

public class ServicoTurma : ServicoBase<Turma>
{
    private readonly IRepositorioTurma repositorioTurma;

    public ServicoTurma(IRepositorioTurma repositorioTurma)
    {
        this.repositorioTurma = repositorioTurma;
    }

    public Result Cadastrar(CadastrarTurmaDto dto)
    {
        Turma turma = new Turma(dto.CursoId, dto.InstrutorId, dto.DataInicio, dto.DataTermino, dto.NumeroMaximoAlunos);

        Result resultadoValidacao = ValidarEntidade(turma);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioTurma.Cadastrar(turma);

        return Result.Ok();
    }

    public Result Editar(EditarTurmaDto dto)
    {
        Turma turma = new Turma(dto.CursoId, dto.InstrutorId, dto.DataInicio, dto.DataTermino, dto.NumeroMaximoAlunos);

        Result resultadoValidacao = ValidarEntidade(turma);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        bool conseguiuEditar = repositorioTurma.Editar(dto.Id, turma);

        if (!conseguiuEditar)
            return Result.Fail("Turma não encontrada.");

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        bool conseguiuExcluir = repositorioTurma.Excluir(id);

        if (!conseguiuExcluir)
            return Result.Fail("Turma não encontrada.");

        return Result.Ok();
    }

    public List<ListarTurmaDto> SelecionarTodos()
    {
        return repositorioTurma
            .SelecionarTodos()
            .Select(t => new ListarTurmaDto(t.Id, t.CursoId, t.InstrutorId, t.DataInicio, t.DataTermino, t.NumeroMaximoAlunos))
            .ToList();
    }

    public Result<DetalhesTurmaDto> SelecionarPorId(Guid id)
    {
        Turma? turma = repositorioTurma.SelecionarPorId(id);

        if (turma == null)
            return Result.Fail("Turma não encontrada.");

        return Result.Ok(new DetalhesTurmaDto(
            turma.Id,
            turma.CursoId,
            turma.InstrutorId,
            turma.DataInicio,
            turma.DataTermino,
            turma.NumeroMaximoAlunos
        ));
    }
}
