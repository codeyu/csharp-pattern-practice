using System;
namespace ObjectBuilderPractice.SqlGenerator
{
    public class SqlGenerator : ISqlGenerator
    {
        public virtual void GenerateSql(ObjectBuilderContext queryContext)
        {
            Console.WriteLine(nameof(SqlGenerator));
        }
    }
}