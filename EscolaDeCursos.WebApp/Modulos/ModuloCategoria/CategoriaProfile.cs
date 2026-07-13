using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCategoria;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCategoria;

public class CategoriaProfile : Profile
{
    public CategoriaProfile()
    {
        CreateMap<ListarCategoriaDto, ListarCategoriasViewModel>()
            .ConstructUsing(src => new ListarCategoriasViewModel(
                src.Id,
                src.Nome
            ));

        CreateMap<CadastrarCategoriaViewModel, CadastrarCategoriaDto>()
            .ConstructUsing(src => new CadastrarCategoriaDto(
                src.Nome
            ));

        CreateMap<EditarCategoriaViewModel, EditarCategoriaDto>()
            .ConstructUsing(src => new EditarCategoriaDto(
                src.Id,
                src.Nome
            ));

        CreateMap<DetalhesCategoriaDto, EditarCategoriaViewModel>()
            .ConstructUsing(src => new EditarCategoriaViewModel(
                src.Id,
                src.Nome
            ));

        CreateMap<DetalhesCategoriaDto, ExcluirCategoriaViewModel>()
            .ConstructUsing(src => new ExcluirCategoriaViewModel(
                src.Id,
                src.Nome
            ));
    }
}
