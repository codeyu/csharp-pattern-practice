using System.Collections.Generic;

namespace ObjectBuilderPractice
{
    public class ConfigProvider : IObjectProvider
    {
        private readonly string _id = "SqlServer";

        public ConfigProvider()
        {
        }

        public ConfigProvider(string id)
        {
            _id = id;
        }

        public Dictionary<string, string> Options
        {
            get
            {
                if (_id == "1")
                {
                    return new Dictionary<string, string> {{"platform","SqlServer"}};
                }
                return new Dictionary<string, string> {{"platform","Another"}};
            }
        }
    }
}