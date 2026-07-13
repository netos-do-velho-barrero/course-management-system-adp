using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using EscolaDeCursos.Infra.Compartilhado.Orm;
using EscolaDeCursos.WebApp.Compartilhado.Infra.Orm;

namespace eAgenda.WebApp.Modulos.ModuloCurso.Infra;

public sealed class RepositorioCursoEmOrm(EscolaDeCursosDbContext dbContext) :
    RepositorioBaseEmOrm<Curso>(dbContext), IRepositorioCurso
{
    public bool ExisteTitulo(string titulo, Guid? idIgnorado = null)
    {
        return registros.Any(x =>
            x.Nome == titulo &&
            (!idIgnorado.HasValue || x.Id != idIgnorado.Value)
        );
    }
}
