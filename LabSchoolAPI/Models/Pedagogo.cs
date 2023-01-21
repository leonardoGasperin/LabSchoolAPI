using System.ComponentModel.DataAnnotations.Schema;

namespace LabSchoolAPI.Models
{
    [Table("Pedagogos")]
    public class Pedagogo : Pessoa
    {
        public int QtdAtendimentos { get; set; }

    }

}
