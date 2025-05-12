using AgendaMed.Models;

namespace AgendaMed.Repositories
{
    public static class EspecialidadeRepository
    {
        private static readonly List<Especialidade> _especialidades = new();
        private static int _nextId = 1;

        public static Especialidade Adicionar(Especialidade especialidade)
        {
            especialidade.Id = _nextId++;
            _especialidades.Add(especialidade);
            return especialidade;
        }

        public static List<Especialidade> Listar()
        {
            return _especialidades;
        }

        public static Especialidade? ObterPorId(int id)
        {
            return _especialidades.FirstOrDefault(e => e.Id == id);
        }
    }
}
