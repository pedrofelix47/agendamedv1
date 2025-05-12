using AgendaMed.Models;

namespace AgendaMed.Repositories
{
    public static class AtendimentoRepository
    {
        private static readonly List<Atendimento> _atendimentos = new();
        private static int _nextId = 1;

        public static Atendimento Adicionar(Atendimento atendimento)
        {
            atendimento.Id = _nextId++;
            atendimento.DataAtendimento = DateTime.UtcNow;
            _atendimentos.Add(atendimento);
            return atendimento;
        }

        public static List<Atendimento> Listar()
        {
            return _atendimentos;
        }

        public static List<Atendimento> BuscarPorFiltro(DateTime? dataInicio, DateTime? dataFim, string? paciente)
        {
            var agendamentos = AgendamentoRepository.Listar();
            return _atendimentos
                .Where(a =>
                {
                    var ag = agendamentos.FirstOrDefault(x => x.Id == a.AgendamentoId);
                    if (ag == null) return false;

                    return (!dataInicio.HasValue || a.DataAtendimento >= dataInicio.Value) &&
                           (!dataFim.HasValue || a.DataAtendimento <= dataFim.Value) &&
                           (string.IsNullOrWhiteSpace(paciente) || ag.Paciente.Contains(paciente, StringComparison.OrdinalIgnoreCase));
                })
                .ToList();
        }
    }
}
