using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabSchoolAPI.Context;
using LabSchoolAPI.Models;
using AutoMapper;
using LabSchoolAPI.Abstract;
using LabSchoolAPI.Models.Dto.AlunoDTO;

namespace LabSchoolAPI.Controllers
{
    [Route("api/alunos")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly LabSchoolApiContext _context;
        private readonly IMapper _mapper;

        public AlunoController(LabSchoolApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<AlunoResponseDTO>>> GetAlunos(string? situacao)
        {
            List<AlunoResponseDTO> listaRetorno = new();

            if (_context.Alunos is null)
            {
                return NotFound();
            }

            List<Aluno> prepararResponse = await _context.Alunos.ToListAsync();

            foreach (Aluno aluno in prepararResponse)
            {
                listaRetorno.Add(_mapper.Map<AlunoResponseDTO>(aluno));
            }

            if (situacao is not null)
            {
                listaRetorno = listaRetorno.Where(w => w.Situacao == situacao.ToUpper()).ToList();
            }
            if(listaRetorno.Count <= 0)
            {
                return NotFound("Situação de matricula invalido.");
            }

            return listaRetorno;

        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult<AlunoResponseDTO>> GetAluno(int codigo)
        {
            if (_context.Alunos is null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos.FindAsync(codigo);

            if (aluno is null)
            {
                return NotFound("Código invalido");
            }

            return _mapper.Map<AlunoResponseDTO>(aluno);

        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> PutAluno(int codigo, AlunoMatriculaAtualizacaoDTO alunoMatriculaAtualizacaoDTO)
        {
            if (!AlunoExists(codigo))
            {
                return NotFound();
            }

            var aluno = await _context.Alunos.FindAsync(codigo);

            if (aluno is null)
            {
                return NotFound();
            }

            try
            {
                if (!ExistSituacao(alunoMatriculaAtualizacaoDTO.situacao.ToUpper()))
                {
                    return BadRequest("Situação de matricula invalida.");
                }

                var novaSituacao = _mapper.Map<Aluno>(alunoMatriculaAtualizacaoDTO);
                aluno.Situacao = novaSituacao.Situacao.ToUpper();
                _context.Entry(aluno).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<AlunoResponseDTO>(aluno));

        }

        [HttpPost]
        public async Task<ActionResult<AlunoResponseDTO>> PostAluno(AlunoRequestDTO alunoDto)
        {
            Aluno aluno = _mapper.Map<Aluno>(alunoDto);

            if (_context.Alunos is null)
            {
                return Problem("Entity set 'LabSchoolApiContext.Alunos'  is null.");
            }
            if (_context.Alunos.Where(w => w.Cfp == aluno.Cfp).Any())
            {
                return Conflict("CPF ja cadastrado no sistema");
            }
            if (!ExistSituacao(aluno.Situacao))
            {
                return Conflict("Situação de matricula invalida.");
            }

            try
            {
                _context.Alunos.Add(_mapper.Map<Aluno>(alunoDto));
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(PostAluno), new { id = aluno.Codigo }, _mapper.Map<AlunoResponseDTO>(aluno));

        }

        // DELETE: api/alunos/5
        [HttpDelete("{codigo}")]
        public async Task<IActionResult> DeleteAluno(int codigo)
        {
            if (_context.Alunos is null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos.FindAsync(codigo);

            if (aluno is null)
            {
                return NotFound();
            }

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();

            return NoContent();

        }

        private bool AlunoExists(int id)
        {
            return (_context.Alunos?.Any(e => e.Codigo == id)).GetValueOrDefault();

        }

        private bool ExistSituacao(string situacao)
        {
            return Enum.GetNames(typeof(MatriculaSituacao)).ToList()
                                    .Where(d => d == situacao).FirstOrDefault() is not null;

        }

    }

}
