using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabSchoolAPI.Context;
using LabSchoolAPI.Models;
using AutoMapper;
using LabSchoolAPI.Models.Dto.PedagogoDTO;

namespace LabSchoolAPI.Controllers
{
    [Route("api/pedagogos")]
    [ApiController]
    public class PedagogoController : ControllerBase
    {
        private readonly LabSchoolApiContext _context;
        private readonly IMapper _mapper;

        public PedagogoController(LabSchoolApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedagogoResponseDTO>>> GetPedagogos()
        {
            if (_context.Pedagogos is null)
            {
                return NotFound();
            }

            List<Pedagogo> prepararRetorno = await _context.Pedagogos.ToListAsync();
            List<PedagogoResponseDTO> listaRetorno = new List<PedagogoResponseDTO>();

            foreach (Pedagogo pedagogo in prepararRetorno)
            {
                listaRetorno.Add(_mapper.Map<PedagogoResponseDTO>(pedagogo));
            }

            return listaRetorno;

        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult<PedagogoResponseDTO>> GetPedagogo(int codigo)
        {
            if (_context.Pedagogos == null)
            {
                return NotFound();
            }
            var pedagogo = await _context.Pedagogos.FindAsync(codigo);

            if (pedagogo == null)
            {
                return NotFound();
            }

            return _mapper.Map<PedagogoResponseDTO>(pedagogo);

        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> PutPedagogo(int codigo, Pedagogo pedagogo)
        {
            if (codigo != pedagogo.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(pedagogo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedagogoExists(codigo))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();

        }

        [HttpPost]
        public async Task<ActionResult<Pedagogo>> PostPedagogo(Pedagogo pedagogo)
        {
            if (_context.Pedagogos is null)
            {
                return Problem("Entity set 'LabSchoolApiContext.Pedagogos'  is null.");
            }
            try
            {
                _context.Pedagogos.Add(pedagogo);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(PostPedagogo), new { id = pedagogo.Codigo }, _mapper.Map<PedagogoResponseDTO>(pedagogo));

        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> DeletePedagogo(int codigo)
        {
            if (_context.Pedagogos is null)
            {
                return NotFound();
            }
            var pedagogo = await _context.Pedagogos.FindAsync(codigo);
            if (pedagogo is null)
            {
                return NotFound();
            }

            _context.Pedagogos.Remove(pedagogo);
            await _context.SaveChangesAsync();

            return NoContent();

        }

        private bool PedagogoExists(int id)
        {
            return (_context.Pedagogos?.Any(e => e.Codigo == id)).GetValueOrDefault();

        }

    }

}
