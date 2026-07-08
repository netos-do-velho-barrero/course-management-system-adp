var builder = WebApplication.CreateBuilder(args);

// Configuração do container de injeção de dependência
// TODO: Injetar camada de infraestrutura
// TODO: Injetar camada de aplicação
// TODO: Injetar camada de apresentação

var app = builder.Build();

// Middlewares de roteamento
app.UseRouting();
app.MapDefaultControllerRoute();

// Execução do Servidor
app.Run();
