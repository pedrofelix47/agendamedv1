using AgendaMed.Models;

namespace AgendaMed.Repositories
{
    public static class AgendamentoRepository
    {
        private static readonly List<Agendamento> _agendamentos = new();
        private static int _nextId = 1;

        public static Agendamento Adicionar(Agendamento agendamento)
        {
            agendamento.Id = _nextId++;
            _agendamentos.Add(agendamento);
            return agendamento;
        }

        public static List<Agendamento> Listar()
        {
            return _agendamentos;
        }

        public static List<Agendamento> BuscarPorData(DateTime data)
        {
            return _agendamentos.Where(a => a.DataHora.Date == data.Date).ToList();
        }

        public static List<Agendamento> BuscarPorFiltro(DateTime? dataInicio, DateTime? dataFim, string? paciente)
        {
            return _agendamentos
                .Where(a =>
                    (!dataInicio.HasValue || a.DataHora >= dataInicio.Value) &&
                    (!dataFim.HasValue || a.DataHora <= dataFim.Value) &&
                    (string.IsNullOrWhiteSpace(paciente) || a.Paciente.Contains(paciente, StringComparison.OrdinalIgnoreCase)))
                .ToList();
        }

        public static bool ExisteAgendamentoNoHorario(string medico, DateTime horario)
        {
            return _agendamentos.Any(a => a.Medico == medico && a.DataHora == horario);
        }

        public static Agendamento? ObterPorId(int id)
        {
            return _agendamentos.FirstOrDefault(a => a.Id == id);
        }
    }
}
