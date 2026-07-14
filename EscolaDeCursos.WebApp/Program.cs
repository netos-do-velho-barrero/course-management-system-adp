using EscolaDeCursos.Aplicacao;
using EscolaDeCursos.Infra;
using EscolaDeCursos.Infra.Compartilhado.Orm;
using EscolaDeCursos.WebApp.Compartilhado;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Configuração do container de injeção de dependência

builder.Services.AddInfraRepositories(builder.Configuration, builder.Logging);
builder.Services.AddApplicationServices();
builder.Services.AddPresentationConfig(builder.Configuration);
builder.Services.AddHealthChecks()
    .AddDbContextCheck<EscolaDeCursosDbContext>(
        name: "database_check",
        failureStatus: HealthStatus.Unhealthy,
        tags: ["ready"]
    );

var app = builder.Build();

// Middlewares de roteamento
app.UseRouting();
app.MapDefaultControllerRoute();

app.MapHealthChecks("/health");

app.Run();
// Execução do Servidor
