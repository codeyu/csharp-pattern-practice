using System.Collections.Generic;

namespace ObjectBuilderPractice
{
    public interface IObjectProvider
    {
        Dictionary<string, string> Options { get; }
    }
}