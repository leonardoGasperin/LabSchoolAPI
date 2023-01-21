using System.ComponentModel.DataAnnotations.Schema;

namespace LabSchoolAPI.Models
{
    [Table("Alunos")]
    public class Aluno : Pessoa
    {
        [Column("SituacaoMatricula")]
        public string Situacao { get; set; }

        public float Nota { get; set; }

        [Column("QtdAtendimentos")]
        public int Atendimento { get; set; }

    }

}
