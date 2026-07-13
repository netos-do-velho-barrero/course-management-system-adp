using EscolaDeCursos.Dominio.Compartilhado;

namespace EscolaDeCursos.Dominio.Modulos.ModuloMatricula;

public interface IRepositorioMatricula : IRepositorio<Matricula>
{
    bool ExisteMatriculaNaTurma(Guid alunoId, Guid turmaId, Guid? idIgnorado = null); 
    int ContarMatriculasAtivasNaTurma(Guid turmaId);
}
