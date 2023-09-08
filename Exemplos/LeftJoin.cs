using System.Linq;

namespace EfCoreQueries.Exemplos
{
    public class LeftJoin : ExemploBase
    {
        public override void Execute()
        {
            //Exemplo 1
            var query1 = from professor in Context.Professores
                        join turma in Context.Turmas on professor.ProfessorId equals turma.ProfessorId into turmaLeftJoin
                        from turmaLeft in turmaLeftJoin.DefaultIfEmpty()
                        select new
                        {
                            NomeProfessor = professor.Nome,
                            NomeDisciplina = turmaLeft.Disciplina.Nome
                        };

            PrintSql(query1);

            //Exemplo 2
            var query2 = Context.Professores.GroupJoin(
                Context.Turmas,
                professor => professor.ProfessorId,
                turma => turma.ProfessorId,
                (professor, turmas) =>
                new
                {
                    professor,
                    turmas = turmas.DefaultIfEmpty()
                }).SelectMany(
                    result => result.turmas,
                    (professor, turma) => new
                    {
                        NomeProfessor = professor.professor,
                        NomeDisciplina = turma.Disciplina.Nome
                    });

            PrintSql(query2);
        }
    }
}
