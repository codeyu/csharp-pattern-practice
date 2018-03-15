using Microsoft.Extensions.Options;

namespace ObjectBuilderPractice.SqlExecutor
{
    public class SqlExecutorFactory : BaseFactory
    {
        public SqlExecutorFactory(ObjectBuilderConfig objectBuilderConfig) : base(objectBuilderConfig)
        {
        }

        public ISqlExecutor GetSqlExecutor(ObjectBuilderContext context) => GetConcreateComponent<ISqlExecutor>(context, ComponentType.SqlExecutor);
    }
}