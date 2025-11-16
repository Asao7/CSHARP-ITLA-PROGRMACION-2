using Microsoft.AspNetCore.Mvc;
using TransporteEscolar.API.Models;
using TransporteEscolar.Domain.Entities;
using TransporteEscolar.Infrastructure.Interfaces;

namespace TransporteEscolar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudianteRutasController : ControllerBase
    {
        private readonly IEstudianteRutaRepository _repository;

        public EstudianteRutasController(IEstudianteRutaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstudianteRutaDto>>> GetAll()
        {
            var lista = await _repository.GetAllAsync();

            var result = lista.Select(x => new EstudianteRutaDto
            {
                Id = x.Id,
                EstudianteId = x.EstudianteId,
                EstudianteNombre = x.Estudiante?.Nombre ?? "",
                RutaId = x.RutaId,
                RutaNombre = x.Ruta?.Nombre ?? "",
                Turno = x.Turno
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EstudianteRutaDto>> Get(int id)
        {
            var x = await _repository.GetByIdAsync(id);
            if (x == null) return NotFound();

            return Ok(new EstudianteRutaDto
            {
                Id = x.Id,
                EstudianteId = x.EstudianteId,
                EstudianteNombre = x.Estudiante?.Nombre ?? "",
                RutaId = x.RutaId,
                RutaNombre = x.Ruta?.Nombre ?? "",
                Turno = x.Turno
            });
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateEstudianteRutaDto dto)
        {
            var entity = new EstudianteRuta
            {
                EstudianteId = dto.EstudianteId,
                RutaId = dto.RutaId,
                Turno = dto.Turno
            };

            await _repository.AddAsync(entity);
            return CreatedAtAction(nameof(Get), new { id = entity.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateEstudianteRutaDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.EstudianteId = dto.EstudianteId;
            existing.RutaId = dto.RutaId;
            existing.Turno = dto.Turno;
            existing.FechaModificacion = DateTime.Now;

            await _repository.UpdateAsync(existing);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
