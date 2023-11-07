using SimpleJudicialProcessAPI.Models;

namespace SistemaPoc.Models
{
    public class Reclamante: PessoaModel<Reclamante>
    {
        public Reclamante()
        {
            CPF = string.Empty;
        }

        public string CPF { get; set; }

        public override void Atualizar(Reclamante reclamante) 
        {
            Nome = reclamante.Nome;
            CPF = reclamante.CPF;
        }
    }
}
