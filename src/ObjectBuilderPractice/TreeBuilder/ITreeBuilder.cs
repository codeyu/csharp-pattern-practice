using System.Collections.Generic;

namespace ObjectBuilderPractice.TreeBuilder
{
    public interface ITreeBuilder
    {
         void GenerateAnalysisTree(ObjectBuilderContext context);
    }
}