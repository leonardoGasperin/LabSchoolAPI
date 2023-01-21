using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabSchoolAPI.Models
{
    public class Pessoa
    {
        [Key]
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        [Column("DataNascimento")]
        public DateTime DataNascimento { get; set; }
        public long Cfp { get; set; }

    }

}
