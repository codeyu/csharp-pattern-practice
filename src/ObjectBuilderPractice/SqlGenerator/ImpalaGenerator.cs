using System;
namespace ObjectBuilderPractice.SqlGenerator
{
    public class ImpalaGenerator : SqlGenerator 
    {
        public override void GenerateSql(ObjectBuilderContext queryContext)
        {
            Console.WriteLine(nameof(ImpalaGenerator));
        }
    }
}