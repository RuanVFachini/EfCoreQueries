using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfCoreQueries.Entities
{
    public class SalaDeAula
    {
        [Key]
        public int SalaDeAulaId { get; set; }

        [Required]
        public string Numero { get; set; }

        public ICollection<Turma> Turmas { get; set; } = new List<Turma>();
    }
}
