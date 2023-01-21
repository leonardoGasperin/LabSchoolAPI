using LabSchoolAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LabSchoolAPI.Context
{
    public class LabSchoolApiContext : DbContext
    {
        public LabSchoolApiContext(DbContextOptions<LabSchoolApiContext> options) : base(options) { }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Pedagogo> Pedagogos { get; set; }

    }

}
