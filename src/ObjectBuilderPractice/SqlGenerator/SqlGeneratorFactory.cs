using Microsoft.Extensions.Options;

namespace ObjectBuilderPractice.SqlGenerator
{
    public class SqlGeneratorFactory : BaseFactory
    {
        public SqlGeneratorFactory(ObjectBuilderConfig objectBuilderConfig) : base(objectBuilderConfig)
        {
        }

        public ISqlGenerator GetSqlGenerator(ObjectBuilderContext context) =>
            GetConcreateComponent<ISqlGenerator>(context, ComponentType.SqlGenerator);
    }
}