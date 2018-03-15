namespace ObjectBuilderPractice.SqlExecutor
{
    public interface ISqlExecutor
    {
         DataResult ExecuteQuery(ObjectBuilderContext queryContext);
    }
}