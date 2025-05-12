using AgendaMed.Models;

namespace AgendaMed.Repositories
{
    public static class ConvenioRepository
    {
        private static readonly List<Convenio> _convenios = new();
        private static int _nextId = 1;

        public static Convenio Adicionar(Convenio convenio)
        {
            convenio.Id = _nextId++;
            _convenios.Add(convenio);
            return convenio;
        }

        public static List<Convenio> Listar()
        {
            return _convenios;
        }

        public static Convenio? ObterPorId(int id)
        {
            return _convenios.FirstOrDefault(c => c.Id == id);
        }
    }
}
