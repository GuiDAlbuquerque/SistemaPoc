using Microsoft.EntityFrameworkCore;
using SistemaPoc.Data;
using SistemaPoc.Models;
using SistemaPoc.Repositorys.Interfaces;

namespace SistemaPoc.Repositorys
{
    public class ReclamanteRepository : IReclamanteRepository
    {
        private readonly SistemaPocDbContext _sistemaPocDbContext;

        public ReclamanteRepository(SistemaPocDbContext sistemaPocDbContext)
        {
            _sistemaPocDbContext = sistemaPocDbContext;
        }

        public async Task<Reclamante> BuscarPorId(int id) => 
            await _sistemaPocDbContext.Reclamante.FirstOrDefaultAsync(reclamante => reclamante.Id == id);
        
        public async Task<List<Reclamante>> BuscarTodos() => 
            await _sistemaPocDbContext.Reclamante.ToListAsync();
        
        public async Task<Reclamante> Adicionar(Reclamante reclamante)
        {
            await _sistemaPocDbContext.Reclamante.AddAsync(reclamante);
            await _sistemaPocDbContext.SaveChangesAsync();
            return reclamante;
        }

        public async Task<Reclamante> Atualizar(Reclamante reclamante, int id)
        {
            var reclamanteComId = await BuscarPorId(id);
            if (reclamanteComId == null)
                throw new Exception($"Reclamante para o ID:{id} não foi encontrado");
            reclamanteComId.AtualizarReclamante(reclamante);
            _sistemaPocDbContext.Reclamante.Update(reclamanteComId);
            await _sistemaPocDbContext.SaveChangesAsync();
            return reclamanteComId;
        }

        public async Task<bool> Apagar(int id)
        {
            var reclamanteComId = await BuscarPorId(id);
            if (reclamanteComId == null)
                throw new Exception($"Usuario para o ID:{id} não foi encontrado");
            _sistemaPocDbContext.Reclamante.Remove(reclamanteComId);
            await _sistemaPocDbContext.SaveChangesAsync();
            return true;
        }
    }
}
