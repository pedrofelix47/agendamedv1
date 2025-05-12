using AgendaMed.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Habilita CORS para permitir acesso de front-ends locais, se necessário
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Usa CORS
app.UseCors();

// Mapeia todos os endpoints definidos nos controllers
app.MapEspecialidadesEndpoints();
app.MapConveniosEndpoints();
app.MapDisponibilidadesEndpoints();
app.MapAgendamentosEndpoints();
app.MapAtendimentosEndpoints();

// Endpoint básico de verificação
app.MapGet("/", () => "API AgendaMed Online");

app.Run();
