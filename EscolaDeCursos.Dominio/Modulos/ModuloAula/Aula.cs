using EscolaDeCursos.Dominio.Compartilhado;

namespace EscolaDeCursos.Dominio.Modulos.ModuloAula;

public class Aula : EntidadeBase<Aula>
{
    public string Titulo { get; set; } = string.Empty;
    public Guid CursoId { get; set; }
    public int Ordem { get; set; }
    public int Duracao { get; set; }

    public Aula()
    {
        
    }

    public Aula(string titulo, Guid cursoId, int ordem, int duracao)
    {
        Titulo = titulo;
        CursoId = cursoId;
        Ordem = ordem;
        Duracao = duracao;
    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (string.IsNullOrWhiteSpace(Titulo))
            erros.Add("O campo 'Título' é obrigatório.");

        if (CursoId == Guid.Empty)
            erros.Add("Todo módulo deve pertencer obrigatoriamente a um curso.");

        if (Ordem <= 0)
            erros.Add("O campo 'Ordem' é obrigatório e deve ser maior que zero.");

        if (Duracao <= 0)
            erros.Add("A duração do módulo deve ser maior que zero.");

        return erros;
    }

    public override void Atualizar(Aula entidadeAtualizada)
    {
        Titulo = entidadeAtualizada.Titulo;
        CursoId = entidadeAtualizada.CursoId;
        Ordem = entidadeAtualizada.Ordem;
        Duracao = entidadeAtualizada.Duracao;
    }
}
