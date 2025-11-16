
using Microsoft.AspNetCore.Mvc;
using TransporteEscolar.Infrastructure.Interfaces;
using TransporteEscolar.API.Models;
using TransporteEscolar.Domain.Entities;

namespace TransporteEscolar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudianteRepository _repository;

        public EstudiantesController(IEstudianteRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Estudiantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstudianteDto>>> GetEstudiantes()
        {
            var estudiantes = await _repository.GetAllAsync();
            var estudiantesDto = estudiantes.Select(e => new EstudianteDto
            {
                EstudianteId = e.EstudianteId,
                Nombre = e.Nombre,
                Apellido = e.Apellido,
                Matricula = e.Matricula,
                Grado = e.Grado,
                Seccion = e.Seccion,
                DireccionResidencia = e.DireccionResidencia,
                TelefonoContacto = e.TelefonoContacto,
                NombrePadre = e.NombrePadre
            });

            return Ok(estudiantesDto);
        }

        // GET: api/Estudiantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstudianteDto>> GetEstudiante(int id)
        {
            var estudiante = await _repository.GetByIdAsync(id);

            if (estudiante == null)
            {
                return NotFound(new { message = "Estudiante no encontrado" });
            }

            var estudianteDto = new EstudianteDto
            {
                EstudianteId = estudiante.EstudianteId,
                Nombre = estudiante.Nombre,
                Apellido = estudiante.Apellido,
                Matricula = estudiante.Matricula,
                Grado = estudiante.Grado,
                Seccion = estudiante.Seccion,
                DireccionResidencia = estudiante.DireccionResidencia,
                TelefonoContacto = estudiante.TelefonoContacto,
                NombrePadre = estudiante.NombrePadre
            };

            return Ok(estudianteDto);
        }

        // POST: api/Estudiantes
        [HttpPost]
        public async Task<ActionResult<EstudianteDto>> CreateEstudiante(CreateEstudianteDto createDto)
        {
            var estudiante = new Estudiante
            {
                Nombre = createDto.Nombre,
                Apellido = createDto.Apellido,
                Matricula = createDto.Matricula,
                Grado = createDto.Grado,
                Seccion = createDto.Seccion,
                DireccionResidencia = createDto.DireccionResidencia,
                TelefonoContacto = createDto.TelefonoContacto,
                NombrePadre = createDto.NombrePadre,
                Estado = true,
                FechaCreacion = DateTime.Now
            };

            var created = await _repository.AddAsync(estudiante);

            var estudianteDto = new EstudianteDto
            {
                EstudianteId = created.EstudianteId,
                Nombre = created.Nombre,
                Apellido = created.Apellido,
                Matricula = created.Matricula,
                Grado = created.Grado,
                Seccion = created.Seccion,
                DireccionResidencia = created.DireccionResidencia,
                TelefonoContacto = created.TelefonoContacto,
                NombrePadre = created.NombrePadre
            };

            return CreatedAtAction(nameof(GetEstudiante), new { id = created.EstudianteId }, estudianteDto);
        }

        // PUT: api/Estudiantes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEstudiante(int id, UpdateEstudianteDto updateDto)
        {
            var estudiante = await _repository.GetByIdAsync(id);
            if (estudiante == null)
            {
                return NotFound(new { message = "Estudiante no encontrado" });
            }

            estudiante.Nombre = updateDto.Nombre;
            estudiante.Apellido = updateDto.Apellido;
            estudiante.Grado = updateDto.Grado;
            estudiante.Seccion = updateDto.Seccion;
            estudiante.DireccionResidencia = updateDto.DireccionResidencia;
            estudiante.TelefonoContacto = updateDto.TelefonoContacto;
            estudiante.NombrePadre = updateDto.NombrePadre;

            await _repository.UpdateAsync(estudiante);

            return NoContent();
        }

        // DELETE: api/Estudiantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudiante(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound(new { message = "Estudiante no encontrado" });
            }

            return NoContent();
        }
    }
}