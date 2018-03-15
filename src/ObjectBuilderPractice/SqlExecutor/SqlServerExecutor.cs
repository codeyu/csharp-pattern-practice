using System;
namespace ObjectBuilderPractice.SqlExecutor
{
    public class SqlServerExecutor : SqlExecutor
    {
        public override DataResult ExecuteQuery(ObjectBuilderContext queryContext)
        {
            Console.WriteLine(nameof(SqlServerExecutor));
            return null;
        }
    }
}