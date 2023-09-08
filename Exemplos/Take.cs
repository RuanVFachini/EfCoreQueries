using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreQueries.Exemplos
{
    public class Take : ExemploBase
    {
        public override void Execute()
        {
            //Exemplo 1
            var query1 = from professor in Context.Professores
                         join turma in Context.Turmas.Take(1) on professor.ProfessorId equals turma.ProfessorId into turmaLeftJoin
                         from turmaLeft in turmaLeftJoin.DefaultIfEmpty()
                         select new
                         {
                             NomeProfessor = professor.Nome,
                             NomeDisciplina = turmaLeft.Disciplina.Nome
                         };

            PrintSql(query1);

            //Exemplo 2
            var query2 = Context.Professores.Join(
                Context.Turmas.Take(1),
                professor => professor.ProfessorId,
                turma => turma.ProfessorId,
                (professor, turma) =>
                new
                {
                    NomeProfessor = professor.Nome,
                    NomeDisciplina = turma.Disciplina.Nome
                });

            PrintSql(query2);

            //Exemplo 1
            var query3 = from professor in Context.Professores.Take(1)
                         from turma in Context.Turmas.Take(1)
                         select new
                         {
                             NomeProfessor = professor.Nome,
                             NomeDisciplina = turma.Nome
                         };

            PrintSql(query3);
        }
    }
}
