namespace ObjectBuilderPractice.TreeBuilder
{
    public class AnalysisTreeBuilder : ITreeBuilder
    {
        public virtual void GenerateAnalysisTree(ObjectBuilderContext context)
        {
            System.Console.WriteLine(nameof(AnalysisTreeBuilder));
        }
    }
}