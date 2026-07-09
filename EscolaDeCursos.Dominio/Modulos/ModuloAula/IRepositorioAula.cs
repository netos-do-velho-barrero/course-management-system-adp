using EscolaDeCursos.Dominio.Compartilhado;

namespace EscolaDeCursos.Dominio.Modulos.ModuloAula;

public interface IRepositorioModuloAula : IRepositorio<ModuloAula>
{
    bool ExisteOrdemNoCurso(int ordem, Guid cursoId, Guid? idIgnorado = null);
}
