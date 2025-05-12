using AgendaMed.Models;

namespace AgendaMed.Repositories
{
    public static class DisponibilidadeRepository
    {
        private static readonly List<Disponibilidade> _disponibilidades = new();
        private static int _nextId = 1;

        public static Disponibilidade Adicionar(Disponibilidade disp)
        {
            disp.Id = _nextId++;
            _disponibilidades.Add(disp);
            return disp;
        }

        public static List<Disponibilidade> Listar()
        {
            return _disponibilidades;
        }

        public static List<Disponibilidade> BuscarPorEspecialidade(int especialidadeId)
        {
            return _disponibilidades.Where(d => d.EspecialidadeId == especialidadeId).ToList();
        }

        public static List<Disponibilidade> BuscarPorEspecialidadeEDia(int especialidadeId, DayOfWeek dia, string? medico = null)
        {
            return _disponibilidades
                .Where(d =>
                    d.EspecialidadeId == especialidadeId &&
                    Enum.TryParse<DayOfWeek>(d.DiaSemana, out var diaSemana) &&
                    diaSemana == dia &&
                    (string.IsNullOrEmpty(medico) || d.Medico == medico))
                .ToList();
        }
    }
}
