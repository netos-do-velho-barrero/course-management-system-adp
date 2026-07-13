using EscolaDeCursos.Dominio.Compartilhado;

namespace EscolaDeCursos.Dominio.Modulos.ModuloCategoria;

public interface IRepositorioCategoria : IRepositorio<Categoria>
{
    bool ExisteNome(string nome, Guid? idIgnorado = null);
}
