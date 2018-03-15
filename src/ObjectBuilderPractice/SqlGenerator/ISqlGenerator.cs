namespace ObjectBuilderPractice.SqlGenerator
{
    public interface ISqlGenerator
    {
         void GenerateSql(ObjectBuilderContext queryContext);
    }
}