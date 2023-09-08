using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfCoreQueries.Entities
{
    public class Disciplina
    {
        [Key]
        public int DisciplinaId { get; set; }

        [Required]
        public string Nome { get; set; }

        public ICollection<Turma> Turmas { get; set; } = new List<Turma>();
    }
}
