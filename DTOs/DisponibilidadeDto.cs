namespace AgendaMed.DTOs
{
    public class DisponibilidadeDto
    {
        public string Medico { get; set; } = string.Empty;
        public int EspecialidadeId { get; set; }
        public string DiaSemana { get; set; } = string.Empty;
        public string HoraInicio { get; set; } = string.Empty; // Ex: "08:00"
        public string HoraFim { get; set; } = string.Empty;    // Ex: "12:00"
        public int DuracaoConsultaMinutos { get; set; }
    }
}
