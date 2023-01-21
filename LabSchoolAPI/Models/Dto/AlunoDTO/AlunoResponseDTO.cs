namespace LabSchoolAPI.Models.Dto.AlunoDTO
{
    public class AlunoResponseDTO
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string DataNascimento { get; set; }
        public long Cfp { get; set; }
        public string Situacao { get; set; }
        public float Nota { get; set; }
        public int Atendimento { get; set; }

    }

}
