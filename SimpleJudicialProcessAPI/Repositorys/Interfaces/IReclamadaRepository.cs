using SistemaPoc.Models;

namespace SistemaPoc.Repositorys.Interfaces
{
    public interface IReclamadaRepository
    {
        Task<List<Reclamada>> BuscarTodos();
        Task<Reclamada> BuscarPorId(int id);
        Task<Reclamada> Adicionar(Reclamada reclamada);
        Task<Reclamada> Atualizar(Reclamada reclamada, int id);
        Task<bool> Apagar(int id);
    }
}
