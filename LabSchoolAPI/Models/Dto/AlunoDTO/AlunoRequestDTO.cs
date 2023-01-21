using LabSchoolAPI.Abstract;

namespace LabSchoolAPI.Models.Dto.AlunoDTO
{
    public class AlunoRequestDTO
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public long Cfp { get; set; }
        public MatriculaSituacao Situacao { get; set; }
        public float Nota { get; set; }

    }

}
