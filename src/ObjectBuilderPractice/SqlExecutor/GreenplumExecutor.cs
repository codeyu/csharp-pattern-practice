using System;
namespace ObjectBuilderPractice.SqlExecutor
{
    public class GreenplumExecutor : SqlExecutor
    {
        public override DataResult ExecuteQuery(ObjectBuilderContext queryContext)
        {
            Console.WriteLine(nameof(GreenplumExecutor));
            return null;
        }
    }
}