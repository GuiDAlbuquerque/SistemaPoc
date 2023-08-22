using Microsoft.EntityFrameworkCore;
using SistemaPoc.Data;
using SistemaPoc.Models;
using SistemaPoc.Repositorys.Interfaces;

namespace SistemaPoc.Repositorys
{
    public class ReclamadaRepository : IReclamadaRepository
    {
        private readonly SistemaPocDbContext _sistemaPocDbContext;

        public ReclamadaRepository(SistemaPocDbContext sistemaPocDbContext)
        {
            _sistemaPocDbContext = sistemaPocDbContext;
        }

        public async Task<Reclamada> BuscarPorId(int id) => 
            await _sistemaPocDbContext.Reclamada.FirstOrDefaultAsync(reclamada => reclamada.Id == id);
        
        public async Task<List<Reclamada>> BuscarTodos() =>
            await _sistemaPocDbContext.Reclamada.ToListAsync();
        

        public async Task<Reclamada> Adicionar(Reclamada reclamada)
        {
            await _sistemaPocDbContext.Reclamada.AddAsync(reclamada);
            await _sistemaPocDbContext.SaveChangesAsync();
            return reclamada;
        }

        public async Task<Reclamada> Atualizar(Reclamada reclamada, int id)
        {
            var reclamadaComId = await BuscarPorId(id);
            if (reclamadaComId == null)
                throw new Exception($"Reclamada para o ID:{id} não foi encontrado");
            reclamadaComId.AtualizarReclamada(reclamada);
            _sistemaPocDbContext.Reclamada.Update(reclamadaComId);
            await _sistemaPocDbContext.SaveChangesAsync();
            return reclamadaComId;
        }

        public async Task<bool> Apagar(int id)
        {
            var reclamadaComId = await BuscarPorId(id);
            if (reclamadaComId == null)
                throw new Exception($"Reclamada para o ID:{id} não foi encontrado");
            _sistemaPocDbContext.Reclamada.Remove(reclamadaComId);
            await _sistemaPocDbContext.SaveChangesAsync();
            return true;
        }
    }
}
