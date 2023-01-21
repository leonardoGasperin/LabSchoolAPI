using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabSchoolAPI.Context;
using LabSchoolAPI.Models;
using AutoMapper;
using LabSchoolAPI.Models.Dto.ProfessorDTO;

namespace LabSchoolAPI.Controllers
{
    [Route("api/professores")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly LabSchoolApiContext _context;
        private readonly IMapper _mapper;

        public ProfessorController(LabSchoolApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfessorResponseDTO>>> GetProfessores()
        {
            if (_context.Professores is null)
            {
                return NotFound();
            }

            List<Professor> prepararRetorno = await _context.Professores.ToListAsync();
            List<ProfessorResponseDTO> listaRetorno = new();

            foreach (Professor professor in prepararRetorno)
            {
                listaRetorno.Add(_mapper.Map<ProfessorResponseDTO>(professor));
            }

            return listaRetorno;

        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult<ProfessorResponseDTO>> GetProfessor(int codigo)
        {
            if (_context.Professores is null)
            {
                return NotFound();
            }

            var professor = await _context.Professores.FindAsync(codigo);

            if (professor is null)
            {
                return NotFound();
            }

            return _mapper.Map<ProfessorResponseDTO>(professor);

        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> PutProfessor(int codigo, Professor professor)
        {
            if (codigo != professor.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(professor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessorExists(codigo))
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
        public async Task<ActionResult<Professor>> PostProfessor(Professor professor)
        {
            if (_context.Professores is null)
            {
                return Problem("Entity set 'LabSchoolApiContext.Professores'  is null.");
            }

            try
            {
                _context.Professores.Add(professor);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(PostProfessor), new { id = professor.Codigo }, _mapper.Map<ProfessorResponseDTO>(professor));

        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> DeleteProfessor(int codigo)
        {
            if (_context.Professores is null)
            {
                return NotFound();
            }
            var professor = await _context.Professores.FindAsync(codigo);
            if (professor is null)
            {
                return NotFound();
            }

            _context.Professores.Remove(professor);
            await _context.SaveChangesAsync();

            return NoContent();

        }

        private bool ProfessorExists(int id)
        {
            return (_context.Professores?.Any(e => e.Codigo == id)).GetValueOrDefault();

        }

    }

}
