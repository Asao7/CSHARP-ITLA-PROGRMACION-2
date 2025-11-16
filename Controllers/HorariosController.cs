using Microsoft.AspNetCore.Mvc;
using TransporteEscolar.Application.Interfaces;
using TransporteEscolar.Domain.Entities;

namespace TransporteEscolar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HorariosController : ControllerBase
    {
        private readonly IHorarioRepository _horarioRepository;

        public HorariosController(IHorarioRepository horarioRepository)
        {
            _horarioRepository = horarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _horarioRepository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var horario = await _horarioRepository.GetByIdAsync(id);
            if (horario == null) return NotFound();
            return Ok(horario);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Horario horario)
        {
            var newHorario = await _horarioRepository.AddAsync(horario);
            return CreatedAtAction(nameof(Get), new { id = newHorario.HorarioId }, newHorario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Horario horario)
        {
            if (id != horario.HorarioId) return BadRequest();
            var updated = await _horarioRepository.UpdateAsync(horario);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _horarioRepository.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
