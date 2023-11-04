namespace SistemaPoc.Models
{
    public class Advogado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string OAB { get; set; }

        public void AtualizarAdvogado(Advogado advogado) 
        {
            Nome = advogado.Nome;
            OAB = advogado.OAB;
        }
    }
}
