using EscolaDeCursos.Dominio.Compartilhado;

namespace EscolaDeCursos.Dominio.Modulos.ModuloInstrutor;

public interface IRepositorioInstrutor : IRepositorio<Instrutor>
{
    bool ExisteEmail(string email, Guid? idIgnorado = null);
}
