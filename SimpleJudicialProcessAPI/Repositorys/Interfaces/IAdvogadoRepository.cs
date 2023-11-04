using SistemaPoc.Models;

namespace SistemaPoc.Repositorys.Interfaces
{
    public interface IAdvogadoRepository
    {
        Task<List<Advogado>> BuscarTodos();
        Task<Advogado> BuscarPorId(int id);
        Task<Advogado> Adicionar(Advogado advogado);
        Task<Advogado> Atualizar(Advogado advogado, int id);
        Task<bool> Apagar(int id);
    }
}
