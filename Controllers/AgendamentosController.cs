using AgendaMed.Models;
using AgendaMed.Repositories;
using AgendaMed.Services;

namespace AgendaMed.Controllers
{
    public static class AgendamentosController
    {
        public static void MapAgendamentosEndpoints(this WebApplication app)
        {
            app.MapPost("/api/agendamentos", (Agendamento agendamento) =>
            {
                // Validação de horário disponível
                bool existeConflito = AgendamentoRepository.ExisteAgendamentoNoHorario(agendamento.Medico, agendamento.DataHora);
                if (existeConflito)
                    return Results.BadRequest("Horário já agendado para este médico.");

                var nova = AgendamentoRepository.Adicionar(agendamento);

                // Adiciona nomes de referência para resposta
                var especialidade = EspecialidadeRepository.ObterPorId(agendamento.EspecialidadeId);
                var convenio = ConvenioRepository.ObterPorId(agendamento.ConvenioId);

                return Results.Created($"/api/agendamentos/{nova.Id}", new
                {
                    nova.Id,
                    nova.Paciente,
                    nova.EspecialidadeId,
                    EspecialidadeNome = especialidade?.Nome,
                    nova.ConvenioId,
                    ConvenioNome = convenio?.Nome,
                    nova.DataHora,
                    nova.Medico
                });
            });

            app.MapGet("/api/agendamentos", (
                DateTime? dataInicio,
                DateTime? dataFim,
                string? paciente) =>
            {
                var ags = AgendamentoRepository.BuscarPorFiltro(dataInicio, dataFim, paciente);
                return Results.Ok(ags);
            });
        }
    }
}
