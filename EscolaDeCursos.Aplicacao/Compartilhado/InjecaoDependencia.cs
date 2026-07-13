using Microsoft.Extensions.DependencyInjection;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCategoria;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;
using EscolaDeCursos.Aplicacao.Modulos.ModuloAula;
using EscolaDeCursos.Aplicacao.Modulos.ModuloInstrutor;
using EscolaDeCursos.Aplicacao.Modulos.ModuloAluno;
using EscolaDeCursos.Aplicacao.Modulos.ModuloTurma;
using EscolaDeCursos.Aplicacao.Modulos.ModuloMatricula;

namespace EscolaDeCursos.Aplicacao;

public static class InjecaoDependencia
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ServicoCategoria>();
        // services.AddScoped<ServicoCurso>();
        // services.AddScoped<ServicoAula>();
        // services.AddScoped<ServicoInstrutor>();
        // services.AddScoped<ServicoAluno>();
        // services.AddScoped<ServicoTurma>();
        // services.AddScoped<ServicoMatricula>();

        return services;
    }
}
