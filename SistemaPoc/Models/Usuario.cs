namespace SistemaPoc.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public void AtualizarUsuario(Usuario usuarioAtualizado) 
        { 
            Nome = usuarioAtualizado.Nome;
            Email = usuarioAtualizado.Email;
        }
    }
}
