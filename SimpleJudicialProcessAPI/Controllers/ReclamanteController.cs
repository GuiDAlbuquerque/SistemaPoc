using SistemaPoc.Models;
using Microsoft.AspNetCore.Mvc;
using SimpleJudicialProcessAPI.Repositorys.Interfaces;

namespace SistemaPoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReclamanteController : Controller
    {
        private readonly IBaseRepository<Reclamante> _reclamanteRepository;

        public ReclamanteController(IBaseRepository<Reclamante> reclamanteRepository) =>
            _reclamanteRepository = reclamanteRepository;

        [HttpGet]
        public async Task<ActionResult<List<Reclamante>>> BuscarTodosReclamantes() =>
            Ok(await _reclamanteRepository.BuscarTodos());

        [HttpGet("{id}")]
        public async Task<ActionResult<Reclamante>> BuscarUsuarioPorId(int id) =>
            Ok(await _reclamanteRepository.BuscarPorId(id));

        [HttpPost]
        public async Task<ActionResult<Reclamante>> Cadastrar([FromBody] Reclamante reclamante) =>
            Ok(await _reclamanteRepository.Adicionar(reclamante));

        [HttpPut("{id}")]
        public async Task<ActionResult<Reclamante>> Atualizar([FromBody] Reclamante reclamante) =>
            Ok(await _reclamanteRepository.Atualizar(reclamante));

        [HttpDelete("{id}")]
        public async Task<ActionResult<Advogado>> Deletar(int id) =>
            Ok(await _reclamanteRepository.Apagar(id));
    }
}
