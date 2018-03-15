using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace ObjectBuilderPractice.TreeBuilder
{
    public class TreeBuilderFactory : BaseFactory
    {
        public TreeBuilderFactory(ObjectBuilderConfig objectBuilderConfig) : base(objectBuilderConfig)
        {
        }
        public ITreeBuilder GetTreeBuilder(ObjectBuilderContext context) => GetConcreateComponent<ITreeBuilder>(context, ComponentType.TreeBuilder);
    }
}