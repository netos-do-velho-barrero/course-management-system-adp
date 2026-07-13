using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloInstrutor;

namespace EscolaDeCursos.WebApp.Modulos.ModuloInstrutor;

public class InstrutorProfile : Profile
{
    public InstrutorProfile()
    {
        CreateMap<ListarInstrutorDto, ListarInstrutorViewModel>();

        CreateMap<CadastrarInstrutorViewModel, CadastrarInstrutorDto>();

        CreateMap<DetalhesInstrutorDto, EditarInstrutorViewModel>();
        CreateMap<EditarInstrutorViewModel, EditarInstrutorDto>();

        CreateMap<DetalhesInstrutorDto, ExcluirInstrutorViewModel>();
    }
}
