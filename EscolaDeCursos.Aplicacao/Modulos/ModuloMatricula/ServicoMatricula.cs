using FluentResults;
using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;
using EscolaDeCursos.Dominio.Modulos.ModuloAluno;
using EscolaDeCursos.Dominio.Modulos.ModuloTurma;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloMatricula;

public class ServicoMatricula : ServicoBase<Matricula>
{
    private readonly IRepositorioMatricula repositorioMatricula;
    private readonly IRepositorioAluno repositorioAluno;
    private readonly IRepositorioTurma repositorioTurma;

    public ServicoMatricula(
        IRepositorioMatricula repositorioMatricula,
        IRepositorioAluno repositorioAluno,
        IRepositorioTurma repositorioTurma)
    {
        this.repositorioMatricula = repositorioMatricula;
        this.repositorioAluno = repositorioAluno;
        this.repositorioTurma = repositorioTurma;
    }

   public Result Cadastrar(CadastrarMatriculaDto dto)
{
    // RN24: Somente alunos previamente cadastrados podem ser matriculados
    Aluno? aluno = repositorioAluno.SelecionarPorId(dto.AlunoId);
    if (aluno == null)
        return Falha(nameof(dto.AlunoId), "Aluno não encontrado.");

    // RN25: Somente turmas previamente cadastradas podem receber matrículas
    Turma? turma = repositorioTurma.SelecionarPorId(dto.TurmaId);
    if (turma == null)
        return Falha(nameof(dto.TurmaId), "Turma não encontrada.");

    // RN22: Um aluno não pode ser matriculado duas vezes na mesma turma
    if (repositorioMatricula.ExisteMatriculaNaTurma(dto.AlunoId, dto.TurmaId))
        return Falha(nameof(dto.AlunoId), "Este aluno já está matriculado nesta turma.");

    // RN23: Não pode haver matrículas acima da capacidade máxima da turma
    int matriculasAtivas = repositorioMatricula.ContarMatriculasAtivasNaTurma(dto.TurmaId);
    if (matriculasAtivas >= turma.NumeroMaximoAlunos)
        return Falha(nameof(dto.TurmaId), "A turma já atingiu o número máximo de alunos.");

    Matricula matricula = new Matricula(dto.AlunoId, dto.TurmaId, dto.Situacao);

    Result resultadoValidacao = ValidarEntidade(matricula);
    if (resultadoValidacao.IsFailed)
        return resultadoValidacao;

    repositorioMatricula.Cadastrar(matricula);

    return Result.Ok();
}

    public Result Editar(EditarMatriculaDto dto)
    {
        Matricula? matricula = repositorioMatricula.SelecionarPorId(dto.Id);

        if (matricula == null)
            return Result.Fail("Matrícula não encontrada.");

        matricula.Situacao = dto.Situacao;

        repositorioMatricula.Editar(dto.Id, matricula);

        return Result.Ok();
    }

    public Result Cancelar(Guid id)
    {
        Matricula? matricula = repositorioMatricula.SelecionarPorId(id);

        if (matricula == null)
            return Result.Fail("Matrícula não encontrada.");

        matricula.Situacao = SituacaoMatricula.Cancelada;

        repositorioMatricula.Editar(id, matricula);

        return Result.Ok();
    }

    public Result Concluir(Guid id)
    {
        Matricula? matricula = repositorioMatricula.SelecionarPorId(id);

        if (matricula == null)
            return Result.Fail("Matrícula não encontrada.");

        matricula.Situacao = SituacaoMatricula.Concluida;

        repositorioMatricula.Editar(id, matricula);

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        bool conseguiuExcluir = repositorioMatricula.Excluir(id);

        if (!conseguiuExcluir)
            return Result.Fail("Matrícula não encontrada.");

        return Result.Ok();
    }

    public List<ListarMatriculaDto> SelecionarTodos()
    {
        return repositorioMatricula
            .SelecionarTodos()
            .Select(m => new ListarMatriculaDto(m.Id, m.AlunoId, m.TurmaId, m.DataMatricula, m.Situacao))
            .ToList();
    }

    public Result<DetalhesMatriculaDto> SelecionarPorId(Guid id)
    {
        Matricula? matricula = repositorioMatricula.SelecionarPorId(id);

        if (matricula == null)
            return Result.Fail("Matrícula não encontrada.");

        return Result.Ok(new DetalhesMatriculaDto(
            matricula.Id,
            matricula.AlunoId,
            matricula.TurmaId,
            matricula.DataMatricula,
            matricula.Situacao
        ));
    }
}
