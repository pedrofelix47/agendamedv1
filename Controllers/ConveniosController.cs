using AgendaMed.Models;
using AgendaMed.Repositories;

namespace AgendaMed.Controllers
{
    public static class ConveniosController
    {
        public static void MapConveniosEndpoints(this WebApplication app)
        {
            app.MapPost("/api/convenios", (Convenio convenio) =>
            {
                var novo = ConvenioRepository.Adicionar(convenio);
                return Results.Created($"/api/convenios/{novo.Id}", novo);
            });

            app.MapGet("/api/convenios", () =>
            {
                return Results.Ok(ConvenioRepository.Listar());
            });
        }
    }
}
