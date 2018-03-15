using System;
namespace ObjectBuilderPractice.SqlExecutor
{
    public class SqlExecutor : ISqlExecutor
    {
        public virtual DataResult ExecuteQuery(ObjectBuilderContext queryContext)
        {
            Console.WriteLine(nameof(SqlExecutor));
            return null;
        }
    }
}