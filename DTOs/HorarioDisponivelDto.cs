namespace AgendaMed.DTOs
{
    public class HorarioDisponivelDto
    {
        public string HoraInicio { get; set; } = string.Empty;
        public string HoraFim { get; set; } = string.Empty;
        public bool Disponivel { get; set; }

        public int? AgendamentoId { get; set; }
        public string? Paciente { get; set; }
    }
}
