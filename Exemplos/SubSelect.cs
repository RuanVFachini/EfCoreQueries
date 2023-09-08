using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreQueries.Exemplos
{
    public class SubSelect : ExemploBase
    {
        public override void Execute()
        {
            //Exemplo 1
            var subTurma1 = from turma in Context.Turmas 
                            where turma.Alunos.Count > 3
                            select turma;

            var query1 = from professor in Context.Professores
                         join turma in subTurma1 on professor.ProfessorId equals turma.ProfessorId into turmaLeftJoin
                         from turmaLeft in turmaLeftJoin.DefaultIfEmpty()
                         select new
                         {
                             NomeProfessor = professor.Nome,
                             NomeDisciplina = turmaLeft.Disciplina.Nome
                         };

            PrintSql(query1);

            //Exemplo 2
            var subTurma2 = Context.Turmas.Where(x => x.Alunos.Count > 3);

            var query2 = from professor in Context.Professores
                         join turma in subTurma2 on professor.ProfessorId equals turma.ProfessorId into turmaLeftJoin
                         from turmaLeft in turmaLeftJoin.DefaultIfEmpty()
                         select new
                         {
                             NomeProfessor = professor.Nome,
                             NomeDisciplina = turmaLeft.Disciplina.Nome
                         };

            PrintSql(query2);

            //Exemplo 3
            var subTurma3 = from turma in Context.Turmas
                            where turma.Alunos.Count > 3
                            select turma;

            var query3 = Context.Professores.Join(
                            subTurma3,
                            professor => professor.ProfessorId,
                            turma => turma.ProfessorId,
                            (professor, turma) =>
                            new
                            {
                                NomeProfessor = professor.Nome,
                                NomeDisciplina = turma.Disciplina.Nome
                            });

            PrintSql(query3);

            //Exemplo 4
            var query4 = from professor in Context.Professores
                         join turma in Context.Turmas on professor.ProfessorId equals turma.ProfessorId into turmaLeftJoin
                         from turmaLeft in turmaLeftJoin.DefaultIfEmpty()

                         //consutla para um campo do select 
                         let alunosCount = turmaLeft.Alunos.Count

                         select new
                         {
                             NomeProfessor = professor.Nome,
                             NomeDisciplina = turmaLeft.Disciplina.Nome,
                             AlunosDaTurma = alunosCount //campo que representa uma subquery
                         };

            PrintSql(query4);
        }
    }
}
