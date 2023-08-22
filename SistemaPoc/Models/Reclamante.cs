namespace SistemaPoc.Models
{
    public class Reclamante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }

        public void AtualizarReclamante(Reclamante reclamante) 
        {
            Nome = reclamante.Nome;
            CPF = reclamante.CPF;
        }

    }
}
