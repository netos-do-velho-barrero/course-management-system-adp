using EscolaDeCursos.Dominio.Modulos.ModuloAula;
using EscolaDeCursos.Infra.Compartilhado.Orm;
using EscolaDeCursos.WebApp.Compartilhado.Infra.Orm;

namespace EscolaDeCursos.Infra.Modulos.ModuloAula;

public sealed class RepositorioAulaEmOrm(EscolaDeCursosDbContext dbContext) :
    RepositorioBaseEmOrm<Aula>(dbContext), IRepositorioAula
{
    public bool ExisteOrdemNoCurso(int ordem, Guid cursoId, Guid? idIgnorado = null)
    {
        if (idIgnorado.HasValue)
        {
            return registros.Any(a => a.CursoId == cursoId &&
                                      a.Ordem == ordem &&
                                      a.Id != idIgnorado.Value);
        }

        return registros.Any(a => a.CursoId == cursoId && a.Ordem == ordem);
    }
}
