using SistemaPoc.Models;

namespace SistemaPoc.Repositorys.Interfaces
{
    public interface IReclamanteRepository
    {
        Task<List<Reclamante>> BuscarTodos();
        Task<Reclamante> BuscarPorId(int id);
        Task<Reclamante> Adicionar(Reclamante reclamante);
        Task<Reclamante> Atualizar(Reclamante reclamante, int id);
        Task<bool> Apagar(int id);
    }
}
