using System;
namespace ObjectBuilderPractice.SqlGenerator
{
    public class GreenplumGenerator : SqlGenerator 
    {
        public override void GenerateSql(ObjectBuilderContext queryContext)
        {
            Console.WriteLine(nameof(GreenplumGenerator));
        }
    }
}