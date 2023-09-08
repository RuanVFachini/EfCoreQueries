using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EfCoreQueries.Entities
{
    public class Turma
    {
        [Key]
        public int TurmaId { get; set; }

        [Required]
        public string Nome { get; set; }

        [ForeignKey("Professor")]
        public int ProfessorId { get; set; }

        public Professor Professor { get; set; }

        [ForeignKey("Disciplina")]
        public int DisciplinaId { get; set; }

        public Disciplina Disciplina { get; set; }

        public ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();
    }
}
