using EscolaDeCursos.Dominio.Compartilhado;

namespace EscolaDeCursos.Dominio.Modulos.ModuloAula;

public interface IRepositorioAula : IRepositorio<Aula>
{
    bool ExisteOrdemNoCurso(int ordem, Guid cursoId, Guid? idIgnorado = null);

}
