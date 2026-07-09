using EscolaDeCursos.Dominio.Compartilhado;

namespace EscolaDeCursos.Dominio.Modulos.ModuloAluno;

public interface IRepositorioAluno : IRepositorio<Aluno>
{
    bool ExisteCpf(string cpf, Guid? idIgnorado = null);
}
