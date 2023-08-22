using SistemaPoc.Models;

namespace SistemaPoc.Repositorys.Interfaces
{
    public interface IProcessoRepository
    {
        Task<List<Processo>> BuscarTodos();
        Task<Processo> BuscarPorId(int id);
        Task<Processo> Adicionar(Processo processo);
        Task<Processo> Atualizar(Processo processo, int id);
        Task<bool> Apagar(int id);
    }
}
