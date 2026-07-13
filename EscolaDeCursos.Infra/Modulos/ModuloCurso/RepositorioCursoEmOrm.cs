using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using EscolaDeCursos.Infra.Compartilhado.Orm;
using EscolaDeCursos.WebApp.Compartilhado.Infra.Orm;

namespace EscolaDeCursos.Infra.Modulos.ModuloCurso;

public sealed class RepositorioCursoEmOrm(EscolaDeCursosDbContext dbContext) :
    RepositorioBaseEmOrm<Curso>(dbContext), IRepositorioCurso
{
    public bool ExisteNome(string nome, Guid? idIgnorado = null)
    {
        return registros.Any(x =>
            x.Nome == nome &&
            (!idIgnorado.HasValue || x.Id != idIgnorado.Value)
        );
    }
}
