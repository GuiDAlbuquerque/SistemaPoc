using Microsoft.EntityFrameworkCore;
using SistemaPoc.Data;
using SistemaPoc.Models;
using SistemaPoc.Repositorys.Interfaces;

namespace SistemaPoc.Repositorys
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SistemaPocDbContext _sistemaPocDbContext;

        public UsuarioRepository(SistemaPocDbContext sistemaPocDbContext)
        {
            _sistemaPocDbContext = sistemaPocDbContext;
        }

        public async Task<Usuario> BuscarPorId(int id) =>
            await _sistemaPocDbContext.Usuario.FirstOrDefaultAsync(usuario => usuario.Id == id);
        
        public async Task<List<Usuario>> BuscarTodos() =>
            await _sistemaPocDbContext.Usuario.ToListAsync();
        
        public async Task<Usuario> Adicionar(Usuario usuario)
        {
            await _sistemaPocDbContext.Usuario.AddAsync(usuario);
            await _sistemaPocDbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> Atualizar(Usuario usuario, int id)
        {
            var usuarioComId = await BuscarPorId(id);
            if (usuarioComId == null)
                throw new Exception($"Usuario para o ID:{id} não foi encontrado");
            usuarioComId.AtualizarUsuario(usuario);
            _sistemaPocDbContext.Usuario.Update(usuarioComId);
            await _sistemaPocDbContext.SaveChangesAsync();
            return usuarioComId;
        }

        public async Task<bool> Apagar(int id)
        {
            var usuarioComId = await BuscarPorId(id);
            if (usuarioComId == null)
                throw new Exception($"Usuario para o ID:{id} não foi encontrado");
            _sistemaPocDbContext.Usuario.Remove(usuarioComId);
            await _sistemaPocDbContext.SaveChangesAsync();
            return true;
        }
    }
}
