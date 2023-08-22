using Microsoft.AspNetCore.Mvc;
using SistemaPoc.Models;
using SistemaPoc.Repositorys.Interfaces;

namespace SistemaPoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReclamanteController : Controller
    {
        private readonly IReclamanteRepository _reclamanteRepository;
        public ReclamanteController(IReclamanteRepository reclamanteRepository)
        {
            _reclamanteRepository = reclamanteRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Reclamante>>> BuscarTodosReclamantes()
        {
            var reclamante = await _reclamanteRepository.BuscarTodos();
            return Ok(reclamante);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reclamante>> BuscarUsuarioPorId(int id)
        {
            var reclamante = await _reclamanteRepository.BuscarPorId(id);
            return Ok(reclamante);
        }

        [HttpPost]
        public async Task<ActionResult<Reclamante>> Cadastrar([FromBody] Reclamante reclamante)
        {
            var reclamanteCadastrado = await _reclamanteRepository.Adicionar(reclamante);
            return Ok(reclamanteCadastrado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Reclamante>> Atualizar([FromBody] Reclamante reclamante, int id)
        {
            reclamante.Id = id;
            var reclamanteAtualizado = await _reclamanteRepository.Atualizar(reclamante, id);
            return Ok(reclamanteAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Advogado>> Deletar(int id)
        {
            var deletado = await _reclamanteRepository.Apagar(id);
            return Ok(deletado);
        }
    }
}
