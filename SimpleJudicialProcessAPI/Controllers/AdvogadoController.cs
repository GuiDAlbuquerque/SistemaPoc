using SistemaPoc.Models;
using Microsoft.AspNetCore.Mvc;
using SimpleJudicialProcessAPI.Repositorys.Interfaces;

namespace SistemaPoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvogadoController : Controller
    {
        private readonly IBaseRepository<Advogado> _advogadoRepository;

        public AdvogadoController(IBaseRepository<Advogado> advogadoRepository) =>
            _advogadoRepository = advogadoRepository;

        [HttpGet]
        public async Task<ActionResult<List<Advogado>>> BuscarTodosAdvogados() =>
            Ok(await _advogadoRepository.BuscarTodos());

        [HttpGet("{id}")]
        public async Task<ActionResult<Advogado>> BuscarUsuarioPorId(int id) =>
            Ok(await _advogadoRepository.BuscarPorId(id));

        [HttpPost]
        public async Task<ActionResult<Advogado>> Cadastrar([FromBody] Advogado advogado) =>
            Ok(await _advogadoRepository.Adicionar(advogado));

        [HttpPut("{id}")]
        public async Task<ActionResult<Advogado>> Atualizar([FromBody] Advogado advogado) =>
            Ok(await _advogadoRepository.Atualizar(advogado));

        [HttpDelete("{id}")]
        public async Task<ActionResult<Advogado>> Deletar(int id) =>
            Ok(await _advogadoRepository.Apagar(id));
    }
}
