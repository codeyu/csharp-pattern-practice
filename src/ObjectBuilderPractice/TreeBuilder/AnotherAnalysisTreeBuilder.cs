namespace ObjectBuilderPractice.TreeBuilder
{
    public class AnotherAnalysisTreeBuilder : AnalysisTreeBuilder
    {
        public override void GenerateAnalysisTree(ObjectBuilderContext context)
        {
            System.Console.WriteLine(nameof(AnotherAnalysisTreeBuilder));
        }
    }
}