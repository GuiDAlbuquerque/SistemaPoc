namespace SistemaPoc.Models
{
    public class Processo
    {
        public int Id { get; set; }
        public string CNPJ { get; set; }
        public int AdvogadoId { get; set; }
        public Advogado Advogado { get; set; }
        public int ReclamanteId { get; set; }
        public Reclamante Reclamante { get; set; }
        public int ReclamadaId { get; set; }
        public Reclamada Reclamada { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }


        public void AtualizarProcesso(Processo processo) 
        {
            AdvogadoId = processo.AdvogadoId;
            ReclamanteId = processo.ReclamanteId;
            ReclamadaId= processo.ReclamadaId;
        }
    }
}
