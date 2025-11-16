using Microsoft.AspNetCore.Mvc;
using TransporteEscolar.Application.Interfaces;
using TransporteEscolar.Domain.Entities;


namespace TransporteEscolar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagosController : ControllerBase
    {
        private readonly IPagoRepository _repository;

        public PagosController(IPagoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pago = await _repository.GetByIdAsync(id);
            if (pago == null) return NotFound();
            return Ok(pago);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Pago pago) => Ok(await _repository.AddAsync(pago));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Pago pago)
        {
            if (id != pago.PagoId) return BadRequest();
            var updated = await _repository.UpdateAsync(pago);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _repository.DeleteAsync(id));
    }
}
