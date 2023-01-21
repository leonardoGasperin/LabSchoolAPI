using LabSchoolAPI.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabSchoolAPI.Models
{
    [Table("Professores")]
    public class Professor : Pessoa
    {
        public ProfessorEstado Estado { get; set; }
        public ProfessorExperiencia Experiencia { get; set; }
        [Column("FormacaoAcademica")]
        public ProfessorGraduacao Graduacao { get; set; }

    }

}
