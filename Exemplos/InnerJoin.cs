using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreQueries.Exemplos
{
    public class InnerJoin : ExemploBase
    {
        public override void Execute()
        {
            //Exemplo 1
            var query1 = from professor in Context.Professores
                         join turma in Context.Turmas on professor.ProfessorId equals turma.ProfessorId
                         select new
                         {
                             NomeProfessor = professor.Nome,
                             NomeDisciplina = turma.Disciplina.Nome
                         };

            PrintSql(query1);

            //Exemplo 2
            var query2 = Context.Professores.Join(
                Context.Turmas,
                professor => professor.ProfessorId,
                turma => turma.ProfessorId,
                (professor, turma) =>
                new
                {
                    NomeProfessor = professor.Nome,
                    NomeDisciplina = turma.Disciplina.Nome
                });

            PrintSql(query2);
        }
    }
}
