using System;
namespace ObjectBuilderPractice.SqlGenerator
{
    public class SqlServerGenerator : SqlGenerator 
    {
        public override void GenerateSql(ObjectBuilderContext queryContext)
        {
            Console.WriteLine(nameof(SqlServerGenerator));
        }
    }
}