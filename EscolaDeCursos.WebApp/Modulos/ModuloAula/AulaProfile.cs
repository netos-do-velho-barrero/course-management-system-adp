using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloAula;

namespace EscolaDeCursos.WebApp.Modulos.ModuloAula;

public class AulaProfile : Profile
{
    public AulaProfile()
    {
        CreateMap<ListarAulaDto, ListarAulaViewModel>();
        CreateMap<CadastrarAulaViewModel, CadastrarAulaDto>();
        CreateMap<EditarAulaViewModel, EditarAulaDto>();
        CreateMap<DetalhesAulaDto, EditarAulaViewModel>();
        CreateMap<DetalhesAulaDto, ExcluirAulaViewModel>();
    }
}
