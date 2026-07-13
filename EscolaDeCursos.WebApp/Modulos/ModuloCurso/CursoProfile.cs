using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCurso;

public class CursoProfile : Profile
{
    public CursoProfile()
    {
        CreateMap<ListarCursoDto, ListarCursosViewModel>()
            .ConstructUsing(src => new ListarCursosViewModel(
                src.Id,
                src.Nome,
                src.Descricao,
                src.CargaHoraria,
                src.Nivel,
                src.CategoriaId
            ));

        CreateMap<CadastrarCursoViewModel, CadastrarCursoDto>()
            .ConstructUsing(src => new CadastrarCursoDto(
                src.Nome,
                src.Descricao,
                src.CargaHoraria,
                src.Nivel,
                src.CategoriaId
            ));

        CreateMap<EditarCursoViewModel, EditarCursoDto>()
            .ConstructUsing(src => new EditarCursoDto(
                src.Id,
                src.Nome,
                src.Descricao,
                src.CargaHoraria,
                src.Nivel,
                src.CategoriaId
            ));

        CreateMap<DetalhesCursoDto, EditarCursoViewModel>()
            .ConstructUsing(src => new EditarCursoViewModel(
                src.Id,
                src.Nome,
                src.Descricao,
                src.CargaHoraria,
                src.Nivel,
                src.CategoriaId
            ));

        CreateMap<DetalhesCursoDto, ExcluirCursoViewModel>()
            .ConstructUsing(src => new ExcluirCursoViewModel(
                src.Id,
                src.Nome
            ));
    }
}
