using AgendaMed.Models;
using AgendaMed.Repositories;

namespace AgendaMed.Controllers
{
    public static class AtendimentosController
    {
        public static void MapAtendimentosEndpoints(this WebApplication app)
        {
            app.MapPost("/api/atendimentos", (Atendimento atendimento) =>
            {
                if (AgendamentoRepository.ObterPorId(atendimento.AgendamentoId) == null)
                    return Results.NotFound("Agendamento não encontrado.");

                var novo = AtendimentoRepository.Adicionar(atendimento);
                return Results.Created($"/api/atendimentos/{novo.Id}", novo);
            });

            app.MapGet("/api/atendimentos", (
                DateTime? dataInicio,
                DateTime? dataFim,
                string? paciente) =>
            {
                var atds = AtendimentoRepository.BuscarPorFiltro(dataInicio, dataFim, paciente);
                return Results.Ok(atds);
            });
        }
    }
}
