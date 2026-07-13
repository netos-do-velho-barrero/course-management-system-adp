using EscolaDeCursos.Dominio.Compartilhado;

namespace EscolaDeCursos.Dominio.Modulos.ModuloCurso;

public interface IRepositorioCurso : IRepositorio<Curso>
{
    bool ExisteNome(string titulo, Guid? idIgnorado = null);
}
