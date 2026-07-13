using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;
using EscolaDeCursos.Infra.Compartilhado.Orm;
using EscolaDeCursos.WebApp.Compartilhado.Infra.Orm;

namespace eAgenda.WebApp.Modulos.ModuloCategoria.Infra;

public sealed class RepositorioCategoriaEmOrm(EscolaDeCursosDbContext dbContext) :
    RepositorioBaseEmOrm<Categoria>(dbContext), IRepositorioCategoria
{
    public bool ExisteNome(string nome, Guid? idIgnorado = null)
    {
        return registros.Any(x =>
         x.Nome == nome &&
         (!idIgnorado.HasValue || x.Id != idIgnorado.Value)
        );
    }
}
