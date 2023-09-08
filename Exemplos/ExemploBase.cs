using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EfCoreQueries.Exemplos
{
    public abstract class ExemploBase
    {
        protected EscolaContext Context { get; }

        public ExemploBase()
        {
            Context = new EscolaContext();
        }

        public abstract void Execute();

        protected void PrintSql(IQueryable queryable)
        {
            Console.WriteLine($"Queryable: \r\n".ToUpper());
            var query = queryable.Expression.Print();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(query);

            try
            {
                var sql = queryable.ToQueryString();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"SQL nativo: \r\n".ToUpper());
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(sql);
            } catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"A consulta não pode ser traduzida para SQL nativo: \r\n".ToUpper());
            }
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\r\n\r\n");

        }
    }
}
