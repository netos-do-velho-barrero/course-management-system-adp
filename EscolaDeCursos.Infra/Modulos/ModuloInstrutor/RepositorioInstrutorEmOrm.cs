using EscolaDeCursos.Dominio.Modulos.ModuloInstrutor;
using EscolaDeCursos.Infra.Compartilhado.Orm;
using EscolaDeCursos.WebApp.Compartilhado.Infra.Orm;

namespace EscolaDeCursos.Infra.Orm.Modulos.ModuloInstrutor;

public sealed class RepositorioInstrutorEmOrm(EscolaDeCursosDbContext dbContext) :
    RepositorioBaseEmOrm<Instrutor>(dbContext), IRepositorioInstrutor
{
    public bool ExisteEmail(string email, Guid? idIgnorado = null)
    {
        if (idIgnorado.HasValue)
        {
            return registros.Any(i => i.Email == email && i.Id != idIgnorado.Value);
        }

        return registros.Any(i => i.Email == email);
    }
}
