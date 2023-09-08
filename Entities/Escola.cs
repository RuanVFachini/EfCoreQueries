using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfCoreQueries.Entities
{
    public class Escola
    {
        [Key]
        public int EscolaId { get; set; }

        [Required]
        public string Nome { get; set; }

        public ICollection<SalaDeAula> SalasDeAula { get; set; } = new List<SalaDeAula>();
    }
}
