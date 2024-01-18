using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreQueries.Exemplos
{
    public class GroupBy : ExemploBase
    {
        public override void Execute()
        {
            //Exemplo 1
            var query1 = from aluno in Context.Alunos
                         group aluno by aluno.Nome.Substring(0,3) into alunoGroup
                         select new
                         {
                             nomePrfixo = alunoGroup.Key,
                             quantidade = alunoGroup.Count()

                         };

            PrintSql(query1);

            //Exemplo 2
            Console.WriteLine($"A Consutla abaixo não é compatível com os operadores do banco de dados:\r\n");
            Console.WriteLine($"Só é possível efetuar o select dos campos presentes na cláusula de GroupBy ou funções matemáticas de agregação [Em versões mais recentes do Entity Framework é possível utilizar agregações mais complexas]");

            var query2 = from aluno in Context.Alunos
                         group aluno by aluno.Nome.Substring(0, 3) into alunoGroup
                         select new
                         {

                            nomePrfixo = alunoGroup.Key,
                            quantidade = alunoGroup.Count(),
                            Nomes = alunoGroup.Select(x => x.Nome)

                         };

            PrintSql(query2);
        }
    }
}
