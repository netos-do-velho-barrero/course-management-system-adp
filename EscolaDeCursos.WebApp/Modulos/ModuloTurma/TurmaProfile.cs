using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloTurma;

namespace EscolaDeCursos.WebApp.Modulos.ModuloTurma;

public class TurmaProfile : Profile
{
    public TurmaProfile()
    {
        CreateMap<ListarTurmaDto, ListarTurmaViewModel>();

        CreateMap<CadastrarTurmaViewModel, CadastrarTurmaDto>();

        CreateMap<DetalhesTurmaDto, EditarTurmaViewModel>();
        CreateMap<EditarTurmaViewModel, EditarTurmaDto>();

        CreateMap<DetalhesTurmaDto, ExcluirTurmaViewModel>();
    }
}
