using SistemaPoc.Models;
using Microsoft.AspNetCore.Mvc;
using SimpleJudicialProcessAPI.Repositorys.Interfaces;

namespace SistemaPoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IBaseRepository<Usuario> _usuarioRepository;

        public UsuarioController(IBaseRepository<Usuario> usuarioRepository) =>
            _usuarioRepository = usuarioRepository;

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> BuscarTodosUsuarios() =>
            Ok(await _usuarioRepository.BuscarTodos());

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> BuscarUsuarioPorId(int id) =>
            Ok(await _usuarioRepository.BuscarPorId(id));

        [HttpPost]
        public async Task<ActionResult<Usuario>> Cadastrar([FromBody] Usuario usuario) =>
            Ok(await _usuarioRepository.Adicionar(usuario));

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> Atualizar([FromBody] Usuario usuario) =>
            Ok(await _usuarioRepository.Atualizar(usuario));

        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> Deletar(int id) =>
            Ok(await _usuarioRepository.Apagar(id));
    }
}
