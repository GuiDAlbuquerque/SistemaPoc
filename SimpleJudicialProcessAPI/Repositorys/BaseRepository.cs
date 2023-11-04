using SistemaPoc.Data;
using Microsoft.EntityFrameworkCore;
using SimpleJudicialProcessAPI.Models;
using SimpleJudicialProcessAPI.Repositorys.Interfaces;

namespace SimpleJudicialProcessAPI.Repositorys
{
    public class BaseRepository<T>: IBaseRepository<T> where T : BaseModel<T>
    {
        private readonly SistemaPocDbContext _sistemaPocDbContext;

        public BaseRepository(SistemaPocDbContext sistemaPocDbContext) =>
            _sistemaPocDbContext = sistemaPocDbContext;

        public async Task<T?> BuscarPorId(int id) =>
            await _sistemaPocDbContext.Set<T>().FirstOrDefaultAsync(_ => _.Id == id);

        public async Task<List<T>> BuscarTodos() =>
            await _sistemaPocDbContext.Set<T>().ToListAsync();

        public async Task<T> Adicionar(T model)
        {
            await _sistemaPocDbContext.Set<T>().AddAsync(model);
            await _sistemaPocDbContext.SaveChangesAsync();
            return model;
        }

        public async Task<T> Atualizar(T model)
        {
            var advogadoComId = await BuscarPorId(model.Id);
            if (advogadoComId == null)
                throw new Exception($"Objeto para o ID:{model.Id} não foi encontrado");
            advogadoComId.Atualizar(model);
            _sistemaPocDbContext.Set<T>().Update(advogadoComId);
            await _sistemaPocDbContext.SaveChangesAsync();
            return advogadoComId;
        }

        public async Task<bool> Apagar(int id)
        {
            var advogadoComId = await BuscarPorId(id);
            if (advogadoComId == null)
                throw new Exception($"Objeto para o ID:{id} não foi encontrado");
            _sistemaPocDbContext.Set<T>().Remove(advogadoComId);
            await _sistemaPocDbContext.SaveChangesAsync();
            return true;
        }
    }
}
