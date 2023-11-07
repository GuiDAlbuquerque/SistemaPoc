using SimpleJudicialProcessAPI.Models;

namespace SistemaPoc.Models
{
    public class Advogado: PessoaModel<Advogado>
    {
        public Advogado()
        {
            OAB = string.Empty;
        }

        public string OAB { get; set; }

        public override void Atualizar(Advogado advogado)
        {
            Nome = advogado.Nome;
            OAB = advogado.OAB;
        }
    }
}
