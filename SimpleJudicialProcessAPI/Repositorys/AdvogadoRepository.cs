using Microsoft.EntityFrameworkCore;
using SistemaPoc.Data;
using SistemaPoc.Models;
using SistemaPoc.Repositorys.Interfaces;

namespace SistemaPoc.Repositorys
{
    public class AdvogadoRepository : IAdvogadoRepository
    {
        private readonly SistemaPocDbContext _sistemaPocDbContext;

        public AdvogadoRepository(SistemaPocDbContext sistemaPocDbContext)
        {
            _sistemaPocDbContext = sistemaPocDbContext;
        }

        public async Task<Advogado> BuscarPorId(int id) =>
            await _sistemaPocDbContext.Advogado.FirstOrDefaultAsync(advogado => advogado.Id == id);
        
        public async Task<List<Advogado>> BuscarTodos() => 
            await _sistemaPocDbContext.Advogado.ToListAsync();

        public async Task<Advogado> Adicionar(Advogado advogado)
        {
            await _sistemaPocDbContext.Advogado.AddAsync(advogado);
            await _sistemaPocDbContext.SaveChangesAsync();
            return advogado;
        }

        public async Task<Advogado> Atualizar(Advogado advogado, int id)
        {
            var advogadoComId = await BuscarPorId(id);
            if (advogadoComId == null)
                throw new Exception($"Advogado para o ID:{id} não foi encontrado");
            advogadoComId.AtualizarAdvogado(advogado);
            _sistemaPocDbContext.Advogado.Update(advogadoComId);
            await _sistemaPocDbContext.SaveChangesAsync();
            return advogadoComId;
        }

        public async Task<bool> Apagar(int id)
        {
            var advogadoComId = await BuscarPorId(id);
            if (advogadoComId == null)
                throw new Exception($"Advogado para o ID:{id} não foi encontrado");
            _sistemaPocDbContext.Advogado.Remove(advogadoComId);
            await _sistemaPocDbContext.SaveChangesAsync();
            return true;
        }
    }
}
