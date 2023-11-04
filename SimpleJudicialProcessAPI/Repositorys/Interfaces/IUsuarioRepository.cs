using SistemaPoc.Models;

namespace SistemaPoc.Repositorys.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> BuscarTodos();
        Task<Usuario> BuscarPorId(int id);
        Task<Usuario> Adicionar(Usuario usuario);
        Task<Usuario> Atualizar(Usuario usuario, int id);
        Task<bool> Apagar(int id);
    }
}
