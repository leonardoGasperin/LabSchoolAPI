using LabSchoolAPI.Models.Dto.AlunoDTO;
using LabSchoolAPI.Models.Dto.PedagogoDTO;

namespace LabSchoolAPI.Models.Dto.AtendimentoDTO
{
    public class AtendimentoResponseDTO
    {
        public AlunoResponseDTO Aluno { get; set; }
        public PedagogoResponseDTO Pedagogo { get; set; }

    }

}
