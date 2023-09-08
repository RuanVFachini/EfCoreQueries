using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfCoreQueries.Entities
{
    public class Professor
    {
        [Key]
        public int ProfessorId { get; set; }

        [Required]
        public string Nome { get; set; }

        public ICollection<Turma> Turmas { get; set; } = new List<Turma>();
    }
}
