using ObjectBuilderPractice.SqlExecutor;
using ObjectBuilderPractice.SqlGenerator;
using ObjectBuilderPractice.TreeBuilder;

namespace ObjectBuilderPractice
{
    public class ObjectBuilderManager
    {
        private readonly IObjectProvider _dataProvider;
        private readonly ObjectBuilderConfig _objectBuilderConfig;
        public ObjectBuilderManager(IObjectProvider dataProvider, ObjectBuilderConfig objectBuilderConfig)
        {
            _dataProvider = dataProvider;
            _objectBuilderConfig = objectBuilderConfig;
        }

        public void Execute()
        {
            var context = new ObjectBuilderContext {Options = _dataProvider.Options};
            var treeBuilderFactory = new TreeBuilderFactory(_objectBuilderConfig);
            var treeBuilder = treeBuilderFactory.GetTreeBuilder(context);
            treeBuilder.GenerateAnalysisTree(context);
            var sqlGeneratorFactory = new SqlGeneratorFactory(_objectBuilderConfig);
            var sqlGenerator = sqlGeneratorFactory.GetSqlGenerator(context);
            sqlGenerator.GenerateSql(context);
            var sqlExecutorFactory = new SqlExecutorFactory(_objectBuilderConfig);
            var sqlExecutor = sqlExecutorFactory.GetSqlExecutor(context);
            sqlExecutor.ExecuteQuery(context);
        }
    }
}