using SimpleJudicialProcessAPI.Models;

namespace SistemaPoc.Models
{
    public class Usuario: PessoaModel<Usuario>
    {
        public Usuario()
        {
            Email = string.Empty;
        }

        public string Email { get; set; }

        public override void Atualizar(Usuario usuarioAtualizado) 
        { 
            Nome = usuarioAtualizado.Nome;
            Email = usuarioAtualizado.Email;
        }
    }
}
