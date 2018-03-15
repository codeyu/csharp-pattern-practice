using System;
namespace ObjectBuilderPractice.SqlExecutor
{
    public class ImpalaSqlExecutor : SqlExecutor
    {
        public override DataResult ExecuteQuery(ObjectBuilderContext queryContext)
        {
            Console.WriteLine(nameof(ImpalaSqlExecutor));
            return null;
        }
    }
}