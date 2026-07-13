using EscolaDeCursos.Dominio.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;

namespace EscolaDeCursos.Dominio.Modulos.ModuloCurso;

public class Curso : EntidadeBase<Curso>
{
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public int CargaHoraria { get; set; }
    public NivelCurso Nivel { get; set; }

    public Guid CategoriaId { get; set; }
    public Categoria Categoria { get; set; } = null!;

    public Curso() { }

    public Curso(string nome, string descricao, int cargaHoraria, NivelCurso nivel, Guid categoriaId)
    {
        Nome = nome;
        Descricao = descricao;
        CargaHoraria = cargaHoraria;
        Nivel = nivel;
        CategoriaId = categoriaId;
    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (string.IsNullOrWhiteSpace(Nome) || Nome.Length < 3 || Nome.Length > 100)
            erros.Add("O campo 'Nome' deve conter entre 3 e 100 caracteres.");

        if (string.IsNullOrWhiteSpace(Descricao))
            erros.Add("O campo 'Descrição' é obrigatório.");

        if (CargaHoraria <= 0)
            erros.Add("A Carga Horária deve ser maior que zero.");

        if (CategoriaId == Guid.Empty)
            erros.Add("O curso deve estar obrigatoriamente vinculado a uma categoria.");

        return erros;
    }

    public override void Atualizar(Curso entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        Descricao = entidadeAtualizada.Descricao;
        CargaHoraria = entidadeAtualizada.CargaHoraria;
        Nivel = entidadeAtualizada.Nivel;
        CategoriaId = entidadeAtualizada.CategoriaId;
    }
}
