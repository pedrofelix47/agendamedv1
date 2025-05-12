using AgendaMed.DTOs;
using AgendaMed.Models;
using AgendaMed.Repositories;

namespace AgendaMed.Services
{
    public static class HorarioService
    {
        public static List<HorarioDisponivelDto> ObterHorariosDisponiveis(DisponibilidadeFiltroDto filtro)
        {
            if (!DateTime.TryParse(filtro.Data, out var dataBusca))
                throw new ArgumentException("Data inválida.");

            var diaSemana = dataBusca.DayOfWeek;

            var disponibilidades = DisponibilidadeRepository.BuscarPorEspecialidadeEDia(
                filtro.EspecialidadeId,
                diaSemana,
                filtro.Medico
            );

            var agendamentosDoDia = AgendamentoRepository.BuscarPorData(dataBusca);

            var horarios = new List<HorarioDisponivelDto>();

            foreach (var disponibilidade in disponibilidades)
            {
                TimeSpan horaInicio = disponibilidade.HoraInicio;
                TimeSpan horaFim = disponibilidade.HoraFim;
                var duracao = TimeSpan.FromMinutes(disponibilidade.DuracaoConsultaMinutos);

                for (var hora = horaInicio; hora + duracao <= horaFim; hora = hora.Add(duracao)) // Atualizando aqui para usar o .Add corretamente
                {
                    var horarioInicio = dataBusca.Date.Add(hora); // Hora é do tipo TimeSpan, então está correto
                    var horarioFim = horarioInicio + duracao;

                    var agendamento = agendamentosDoDia.FirstOrDefault(a =>
                        a.EspecialidadeId == disponibilidade.EspecialidadeId &&
                        a.Medico == disponibilidade.Medico &&
                        a.DataHora == horarioInicio
                    );

                    horarios.Add(new HorarioDisponivelDto
                    {
                        HoraInicio = horarioInicio.ToString("HH:mm"),
                        HoraFim = horarioFim.ToString("HH:mm"),
                        Disponivel = agendamento == null,
                        AgendamentoId = agendamento?.Id,
                        Paciente = agendamento?.Paciente
                    });
                }
            }

            return horarios.OrderBy(h => h.HoraInicio).ToList();
        }
    }
}
