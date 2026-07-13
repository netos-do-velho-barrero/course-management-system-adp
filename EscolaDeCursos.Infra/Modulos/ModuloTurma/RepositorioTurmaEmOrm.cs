using EscolaDeCursos.Dominio.Modulos.ModuloTurma;
using EscolaDeCursos.Infra.Compartilhado.Orm;
using EscolaDeCursos.WebApp.Compartilhado.Infra.Orm;

namespace EscolaDeCursos.Infra.Orm.Modulos.ModuloTurma;

public class RepositorioTurmaEmOrm : RepositorioBaseEmOrm<Turma>, IRepositorioTurma
{
    public RepositorioTurmaEmOrm(EscolaDeCursosDbContext dbContext) : base(dbContext)
    {
    }
}
