using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabSchoolAPI.Context;
using LabSchoolAPI.Models;
using AutoMapper;
using LabSchoolAPI.Models.Dto.AtendimentoDTO;
using LabSchoolAPI.Abstract;
using LabSchoolAPI.Models.Dto.AlunoDTO;
using LabSchoolAPI.Models.Dto.PedagogoDTO;

namespace LabSchoolAPI.Controllers
{
    [Route("api/atendimentos")]
    [ApiController]
    public class AtendimentoController : ControllerBase
    {
        private readonly LabSchoolApiContext _context;
        private readonly IMapper _mapper;

        public AtendimentoController(LabSchoolApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPut]
        public async Task<IActionResult> PutAtendimento(AtendimentoRequestDTO atendimentoRequestDTO)
        {
            if (!AlunoExists(atendimentoRequestDTO.AlunoCodigo) || !PedagogoExists(atendimentoRequestDTO.PedagogoCodigo))
            {
                return NotFound();
            }

            Aluno aluno = await _context.Alunos.Where(w => w.Codigo == atendimentoRequestDTO.AlunoCodigo).FirstOrDefaultAsync();
            Pedagogo pedagogo = await _context.Pedagogos.Where(w => w.Codigo == atendimentoRequestDTO.PedagogoCodigo).FirstOrDefaultAsync();

            if (aluno is null || pedagogo is null)
            {
                return NotFound();
            }

            try
            {
                aluno.Situacao = MatriculaSituacao.ATENDIMENTO_PEDAGOGICO.ToString();
                aluno.Atendimento++;
                pedagogo.QtdAtendimentos++;

                _context.Entry(aluno).State = EntityState.Modified;
                _context.Entry(pedagogo).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            AtendimentoResponseDTO atendimentoResponse = new AtendimentoResponseDTO();

            atendimentoResponse.Aluno = _mapper.Map<AlunoResponseDTO>(aluno);
            atendimentoResponse.Pedagogo = _mapper.Map<PedagogoResponseDTO>(pedagogo);

            return Ok(atendimentoResponse);

        }

        private bool AlunoExists(int id)
        {
            return (_context.Alunos?.Any(e => e.Codigo == id)).GetValueOrDefault();

        }

        private bool PedagogoExists(int id)
        {
            return (_context.Pedagogos?.Any(e => e.Codigo == id)).GetValueOrDefault();

        }

    }

}
