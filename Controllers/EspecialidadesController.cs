using AgendaMed.Models;
using AgendaMed.Repositories;

namespace AgendaMed.Controllers
{
    public static class EspecialidadesController
    {
        public static void MapEspecialidadesEndpoints(this WebApplication app)
        {
            app.MapPost("/api/especialidades", (Especialidade especialidade) =>
            {
                var nova = EspecialidadeRepository.Adicionar(especialidade);
                return Results.Created($"/api/especialidades/{nova.Id}", nova);
            });

            app.MapGet("/api/especialidades", () =>
            {
                return Results.Ok(EspecialidadeRepository.Listar());
            });
        }
    }
}
