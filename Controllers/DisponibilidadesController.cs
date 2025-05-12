using AgendaMed.Models;
using AgendaMed.Repositories;
using AgendaMed.Services;
using AgendaMed.DTOs;

namespace AgendaMed.Controllers
{
    public static class DisponibilidadesController
    {
        public static void MapDisponibilidadesEndpoints(this WebApplication app)
        {
            app.MapPost("/api/disponibilidades/definir", (Disponibilidade disponibilidade) =>
            {
                var nova = DisponibilidadeRepository.Adicionar(disponibilidade);
                return Results.Created($"/api/disponibilidades/{nova.Id}", nova);
            });

            app.MapPost("/api/disponibilidades", (DisponibilidadeFiltroDto filtro) =>
            {
                var horarios = HorarioService.ObterHorariosDisponiveis(filtro);
                return Results.Ok(horarios);
            });
        }
    }
}
