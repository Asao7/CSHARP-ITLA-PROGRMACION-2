using Microsoft.AspNetCore.Mvc;
using TransporteEscolar.API.Models;
using TransporteEscolar.Domain.Entities;
using TransporteEscolar.Infrastructure.Interfaces;

namespace TransporteEscolar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChoferesController : ControllerBase
    {
        private readonly IChoferRepository _repo;

        public ChoferesController(IChoferRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var choferes = await _repo.GetAllAsync();
            return Ok(choferes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var chofer = await _repo.GetByIdAsync(id);
            if (chofer == null)
                return NotFound();

            return Ok(chofer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateChoferDto dto)
        {
            var chofer = new Chofer
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Cedula = dto.Cedula,
                Telefono = dto.Telefono,
                LicenciaConducir = dto.LicenciaConducir,
                FechaContratacion = dto.FechaContratacion
            };

            await _repo.AddAsync(chofer);

            return CreatedAtAction(nameof(Get), new { id = chofer.ChoferId }, chofer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateChoferDto dto)
        {
            var chofer = await _repo.GetByIdAsync(id);
            if (chofer == null)
                return NotFound();

            chofer.Telefono = dto.Telefono;
            chofer.LicenciaConducir = dto.LicenciaConducir;

            await _repo.UpdateAsync(chofer);
            return Ok(chofer);
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
