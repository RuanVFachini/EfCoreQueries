using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreQueries.Entities
{
    public class Aluno
    {
        [Key]
        public int AlunoId { get; set; }

        [Required]
        public string Nome { get; set; }

        public int Idade { get; set; }

        public ICollection<Turma> Turmas { get; set; } = new List<Turma>();
    }
}
