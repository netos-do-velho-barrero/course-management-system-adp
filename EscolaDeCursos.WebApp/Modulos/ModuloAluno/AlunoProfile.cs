using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloAluno; // Ajuste para o namespace correto da sua aplicação

namespace EscolaDeCursos.WebApp.Modulos.ModuloAluno;

public class AlunoProfile : Profile
{
    public AlunoProfile()
    {
        CreateMap<ListarAlunoDto, ListarAlunoViewModel>();
        CreateMap<CadastrarAlunoViewModel, CadastrarAlunoDto>();
        CreateMap<EditarAlunoViewModel, EditarAlunoDto>();
        CreateMap<DetalhesAlunoDto, EditarAlunoViewModel>();
        CreateMap<DetalhesAlunoDto, ExcluirAlunoViewModel>();
    }
}
