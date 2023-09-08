using EfCoreQueries.Exemplos;

namespace EfCoreQueries
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            new LeftJoin().Execute();
            new InnerJoin().Execute();
            new ProdutoCartesiano().Execute();
            new Take().Execute();
            new SubSelect().Execute();
            new GroupBy().Execute();
        }
    }
}
