using Microsoft.AspNetCore.Mvc;
using TransporteEscolar.Application.Interfaces;
using TransporteEscolar.Domain.Entities;


namespace TransporteEscolar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RutasController : ControllerBase
    {
        private readonly IRutaRepository _repository;

        public RutasController(IRutaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ruta = await _repository.GetByIdAsync(id);
            if (ruta == null) return NotFound();
            return Ok(ruta);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ruta ruta) => Ok(await _repository.AddAsync(ruta));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Ruta ruta)
        {
            if (id != ruta.RutaId) return BadRequest();
            var updated = await _repository.UpdateAsync(ruta);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _repository.DeleteAsync(id));
    }
}
