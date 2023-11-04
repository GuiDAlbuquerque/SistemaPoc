using Microsoft.EntityFrameworkCore;
using SistemaPoc.Data;
using SistemaPoc.Models;
using SistemaPoc.Repositorys.Interfaces;

namespace SistemaPoc.Repositorys
{
    public class ProcessoRepository : IProcessoRepository
    {
        private readonly SistemaPocDbContext _sistemaPocDbContext;

        public ProcessoRepository(SistemaPocDbContext sistemaPocDbContext)
        {
            _sistemaPocDbContext = sistemaPocDbContext;
        }

        public async Task<Processo> BuscarPorId(int id) =>
            await _sistemaPocDbContext.Processo.FirstOrDefaultAsync(processo => processo.Id == id);
        
        public async Task<List<Processo>> BuscarTodos() =>
            await _sistemaPocDbContext.Processo.ToListAsync();
        
        public async Task<Processo> Adicionar(Processo processo)
        {
            await _sistemaPocDbContext.Processo.AddAsync(processo);
            await _sistemaPocDbContext.SaveChangesAsync();
            return processo;
        }

        public async Task<Processo> Atualizar(Processo processo, int id)
        {
            var processoComId = await BuscarPorId(id);
            if (processoComId == null)
                throw new Exception($"Processo para o ID:{id} não foi encontrado");
            processoComId.AtualizarProcesso(processo);
            _sistemaPocDbContext.Processo.Update(processoComId);
            await _sistemaPocDbContext.SaveChangesAsync();
            return processoComId;
        }

        public async Task<bool> Apagar(int id)
        {
            var processoComId = await BuscarPorId(id);
            if (processoComId == null)
                throw new Exception($"Processo para o ID:{id} não foi encontrado");
            _sistemaPocDbContext.Processo.Remove(processoComId);
            await _sistemaPocDbContext.SaveChangesAsync();
            return true;
        }
    }
}
