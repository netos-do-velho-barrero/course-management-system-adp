using EscolaDeCursos.Dominio.Modulos.ModuloAluno;
using EscolaDeCursos.Infra.Compartilhado.Orm;
using EscolaDeCursos.WebApp.Compartilhado.Infra.Orm;

namespace EscolaDeCursos.Infra.Modulos.ModuloAluno;

public sealed class RepositorioAlunoEmOrm(EscolaDeCursosDbContext dbContext) :
    RepositorioBaseEmOrm<Aluno>(dbContext), IRepositorioAluno
{
    public bool ExisteCpf(string cpf, Guid? idIgnorado = null)
    {
        
        if (idIgnorado.HasValue)
        {
            return registros.Any(a => a.Cpf == cpf && a.Id != idIgnorado.Value);
        }


        return registros.Any(a => a.Cpf == cpf);
    }
}
