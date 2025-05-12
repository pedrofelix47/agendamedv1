namespace AgendaMed.DTOs
{
    public class DisponibilidadeFiltroDto
    {
        public int EspecialidadeId { get; set; }
        public string Data { get; set; } = string.Empty; // "AAAA-MM-DD"
        public string? Medico { get; set; }
    }
}
