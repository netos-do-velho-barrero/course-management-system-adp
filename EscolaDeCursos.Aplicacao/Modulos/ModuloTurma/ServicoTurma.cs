using FluentResults;
using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloTurma;
using EscolaDeCursos.Dominio.Modulos.ModuloInstrutor;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using EscolaDeCursos.Dominio.Modulos.ModuloMatricula; // Dependência adicionada

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloTurma;

public class ServicoTurma : ServicoBase<Turma>
{
    private readonly IRepositorioTurma repositorioTurma;
    private readonly IRepositorioInstrutor repositorioInstrutor;
    private readonly IRepositorioCurso repositorioCurso;
    private readonly IRepositorioMatricula repositorioMatricula; // Repositório adicionado

    public ServicoTurma(
        IRepositorioTurma repositorioTurma,
        IRepositorioInstrutor repositorioInstrutor,
        IRepositorioCurso repositorioCurso,
        IRepositorioMatricula repositorioMatricula) // Injetado no construtor
    {
        this.repositorioTurma = repositorioTurma;
        this.repositorioInstrutor = repositorioInstrutor;
        this.repositorioCurso = repositorioCurso;
        this.repositorioMatricula = repositorioMatricula;
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
        List<Turma> turmas = repositorioTurma.SelecionarTodos();
        var todasMatriculas = repositorioMatricula.SelecionarTodos(); // Busca única para otimização

        return turmas.Select(t =>
        {
            Instrutor? instrutor = repositorioInstrutor.SelecionarPorId(t.InstrutorId);
            Curso? curso = repositorioCurso.SelecionarPorId(t.CursoId);

            int qtdAlunos = todasMatriculas.Count(m => m.TurmaId == t.Id); // Contagem implementada

            return new ListarTurmaDto(
                t.Id,
                t.CursoId,
                curso?.Nome ?? "Curso não encontrado",
                t.InstrutorId,
                instrutor?.Nome ?? "Instrutor não encontrado",
                t.DataInicio,
                t.DataTermino,
                t.NumeroMaximoAlunos,
                qtdAlunos // Propriedade repassada ao DTO
            );
        }).ToList();
    }

    public Result<DetalhesTurmaDto> SelecionarPorId(Guid id)
    {
        Turma? turma = repositorioTurma.SelecionarPorId(id);

        if (turma == null)
            return Result.Fail("Turma não encontrada.");

        Instrutor? instrutor = repositorioInstrutor.SelecionarPorId(turma.InstrutorId);
        Curso? curso = repositorioCurso.SelecionarPorId(turma.CursoId);

        int qtdAlunos = repositorioMatricula.SelecionarTodos().Count(m => m.TurmaId == turma.Id); // Contagem implementada

        return Result.Ok(new DetalhesTurmaDto(
            turma.Id,
            turma.CursoId,
            curso?.Nome ?? "Curso não encontrado",
            turma.InstrutorId,
            instrutor?.Nome ?? "Instrutor não encontrado",
            turma.DataInicio,
            turma.DataTermino,
            turma.NumeroMaximoAlunos,
            qtdAlunos // Propriedade repassada ao DTO
        ));
    }
}
