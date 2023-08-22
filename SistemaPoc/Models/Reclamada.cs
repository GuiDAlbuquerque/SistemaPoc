namespace SistemaPoc.Models
{
    public class Reclamada
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }

        public void AtualizarReclamada(Reclamada reclamada) 
        {
            Nome = reclamada.Nome;
            CNPJ= reclamada.CNPJ;
        }

    }
}
