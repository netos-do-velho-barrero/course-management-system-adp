using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;
using EscolaDeCursos.Infra.Compartilhado.Orm;
using EscolaDeCursos.WebApp.Compartilhado.Infra.Orm;

namespace EscolaDeCursos.Infra.Orm.Modulos.ModuloMatricula;

public sealed class RepositorioMatriculaEmOrm(EscolaDeCursosDbContext dbContext) :
    RepositorioBaseEmOrm<Matricula>(dbContext), IRepositorioMatricula
{
    public bool ExisteMatriculaNaTurma(Guid alunoId, Guid turmaId, Guid? idIgnorado = null)
    {
        if (idIgnorado.HasValue)
        {
            return registros.Any(m =>
                m.AlunoId == alunoId &&
                m.TurmaId == turmaId &&
                m.Situacao != SituacaoMatricula.Cancelada &&
                m.Id != idIgnorado.Value
            );
        }

        return registros.Any(m =>
            m.AlunoId == alunoId &&
            m.TurmaId == turmaId &&
            m.Situacao != SituacaoMatricula.Cancelada
        );
    }

    public int ContarMatriculasAtivasNaTurma(Guid turmaId)
    {
        return registros.Count(m =>
            m.TurmaId == turmaId &&
            m.Situacao == SituacaoMatricula.Ativa
        );
    }
}
