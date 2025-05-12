namespace AgendaMed.Models
{
    public class Atendimento
    {
        public int Id { get; set; }
        public int AgendamentoId { get; set; }
        public DateTime DataAtendimento { get; set; } = DateTime.UtcNow;
        public string? Observacoes { get; set; }
    }
}
