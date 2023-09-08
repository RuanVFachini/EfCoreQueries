using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreQueries.Exemplos
{
    public class ProdutoCartesiano : ExemploBase
    {
        public override void Execute()
        {
            //Exemplo 1
            var query1 = from professor in Context.Professores
                         from turma in Context.Turmas
                         select new
                         {
                             NomeProfessor = professor.Nome,
                             NomeDisciplina = turma.Nome
                         };

            PrintSql(query1);
        }
    }
}
