using FluentResults;
using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;

public class ServicoCurso : ServicoBase<Curso>
{
    private readonly IRepositorioCurso repositorioCurso;

    public ServicoCurso(IRepositorioCurso repositorioCurso)
    {
        this.repositorioCurso = repositorioCurso;
    }

    public Result Cadastrar(CadastrarCursoDto dto)
    {
        if (repositorioCurso.ExisteNome(dto.Nome))
            return Falha(nameof(dto.Nome), "Já existe um curso cadastrado com este título.");

        Curso curso = new Curso(dto.Nome, dto.Descricao, dto.CargaHoraria, dto.Nivel, dto.CategoriaId);

        Result resultadoValidacao = ValidarEntidade(curso);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioCurso.Cadastrar(curso);

        return Result.Ok();
    }

    public Result Editar(EditarCursoDto dto)
    {
        if (repositorioCurso.ExisteNome(dto.Nome, dto.Id))
            return Falha(nameof(dto.Nome), "Já existe um curso cadastrado com este nome.");

        Curso curso = new Curso(
            dto.Nome,
            dto.Descricao,
            dto.CargaHoraria,
            dto.Nivel,
            dto.CategoriaId)
        {
            Id = dto.Id
        };

        Result resultadoValidacao = ValidarEntidade(curso);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        bool conseguiuEditar = repositorioCurso.Editar(dto.Id, curso);

        if (!conseguiuEditar)
            return Result.Fail("Curso não encontrado.");

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        bool conseguiuExcluir = repositorioCurso.Excluir(id);

        if (!conseguiuExcluir)
            return Result.Fail("Curso não encontrado.");

        return Result.Ok();
    }

    public List<ListarCursoDto> SelecionarTodos()
    {
        return repositorioCurso
            .SelecionarTodos()
            .Select(c => new ListarCursoDto(
    c.Id,
    c.Nome,
    c.Descricao,
    c.CargaHoraria,
    c.Nivel,
    c.CategoriaId
))
            .ToList();
    }

    public Result<DetalhesCursoDto> SelecionarPorId(Guid id)
    {
        Curso? curso = repositorioCurso.SelecionarPorId(id);

        if (curso == null)
            return Result.Fail("Curso não encontrado.");

        return Result.Ok(new DetalhesCursoDto(
            curso.Id,
            curso.Nome,
            curso.Descricao,
            curso.CargaHoraria,
            curso.Nivel,
            curso.CategoriaId
        ));
    }
}
