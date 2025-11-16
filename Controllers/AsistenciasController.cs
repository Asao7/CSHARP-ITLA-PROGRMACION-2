using Microsoft.AspNetCore.Mvc;
using TransporteEscolar.API.Models;
using TransporteEscolar.Domain.Entities;
using TransporteEscolar.Infrastructure.Interfaces;

namespace TransporteEscolar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AsistenciasController : ControllerBase
    {
        private readonly IAsistenciaRepository _repo;

        public AsistenciasController(IAsistenciaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var asistencias = await _repo.GetAllAsync();
            return Ok(asistencias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var asistencia = await _repo.GetByIdAsync(id);
            if (asistencia == null)
                return NotFound();

            return Ok(asistencia);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAsistenciaDto dto)
        {
            var asistencia = new Asistencia
            {
                EstudianteId = dto.EstudianteId,
                RutaId = dto.RutaId,
                Fecha = dto.Fecha,
                HoraRegistro = dto.HoraRegistro,
                TipoRuta = dto.TipoRuta,
                Presente = dto.Presente,
                Observaciones = dto.Observaciones
            };

            await _repo.AddAsync(asistencia);

            return CreatedAtAction(nameof(Get), new { id = asistencia.AsistenciaId }, asistencia);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateAsistenciaDto dto)
        {
            var asistencia = await _repo.GetByIdAsync(id);
            if (asistencia == null)
                return NotFound();

            asistencia.HoraRegistro = dto.HoraRegistro;
            asistencia.Presente = dto.Presente;
            asistencia.Observaciones = dto.Observaciones;

            await _repo.UpdateAsync(asistencia);

            return Ok(asistencia);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _repo.DeleteAsync(id);
            if (!eliminado)
                return NotFound();

            return NoContent();
        }
    }
}
