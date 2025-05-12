namespace AgendaMed.DTOs
{
    public class AgendamentoDto
    {
        public string Paciente { get; set; } = string.Empty;
        public int EspecialidadeId { get; set; }
        public int ConvenioId { get; set; }
        public DateTime DataHora { get; set; } // ISO 8601 (Z no fim)
    }
}
