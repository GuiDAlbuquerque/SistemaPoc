using SimpleJudicialProcessAPI.Models;

namespace SistemaPoc.Models
{
    public class Reclamada: PessoaModel<Reclamada>
    {
        public Reclamada()
        {
            CNPJ = string.Empty;
        }

        public string CNPJ { get; set; }

        public override void Atualizar(Reclamada reclamada) 
        {
            Nome = reclamada.Nome;
            CNPJ= reclamada.CNPJ;
        }
    }
}
