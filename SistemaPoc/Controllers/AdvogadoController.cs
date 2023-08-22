using Microsoft.AspNetCore.Mvc;
using SistemaPoc.Models;
using SistemaPoc.Repositorys.Interfaces;

namespace SistemaPoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvogadoController : Controller
    {
        private readonly IAdvogadoRepository _advogadoRepository;
        public AdvogadoController(IAdvogadoRepository advogadoRepository)
        {
            _advogadoRepository = advogadoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Advogado>>> BuscarTodosAdvogados()
        {
            var advogado = await _advogadoRepository.BuscarTodos();
            return Ok(advogado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Advogado>> BuscarUsuarioPorId(int id)
        {
            var advogado = await _advogadoRepository.BuscarPorId(id);
            return Ok(advogado);
        }

        [HttpPost]
        public async Task<ActionResult<Advogado>> Cadastrar([FromBody] Advogado advogado)
        {
            var advogadoCadastrado = await _advogadoRepository.Adicionar(advogado);
            return Ok(advogadoCadastrado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Advogado>> Atualizar([FromBody] Advogado advogado, int id)
        {
            advogado.Id = id;
            var advogadoAtualizado = await _advogadoRepository.Atualizar(advogado, id);
            return Ok(advogadoAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Advogado>> Deletar(int id)
        {
            var deletado = await _advogadoRepository.Apagar(id);
            return Ok(deletado);
        }
    }
}
