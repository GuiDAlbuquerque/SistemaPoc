using SimpleJudicialProcessAPI.Models;

namespace SimpleJudicialProcessAPI.Repositorys.Interfaces
{
    public interface IBaseRepository<T> where T : BaseModel<T>
    {
        Task<List<T>> BuscarTodos();
        Task<T?> BuscarPorId(int id);
        Task<T> Adicionar(T model);
        Task<T> Atualizar(T model);
        Task<bool> Apagar(int id);
    }
}
