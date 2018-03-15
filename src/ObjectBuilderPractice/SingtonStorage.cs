using System.Collections.Generic;

namespace ObjectBuilderPractice
{
    public class SingtonStorage
    {
        private SingtonStorage() { }

        private static readonly SingtonStorage _instance = new SingtonStorage();
        private static object _lock = new object();

        private Dictionary<string, object> _dict = new Dictionary<string, object>();

        public static SingtonStorage Instance
        {
            get
            {
                return _instance;
            }
        }

        public object Get(string key)
        {
            lock (_dict)
            {
                if (_dict.ContainsKey(key))
                {
                    return _dict[key];
                }
                return null;
            }
        }

        public void Set(string key, object value)
        {
            lock (_dict)
            {
                if (_dict.ContainsKey(key))
                {
                    _dict.Remove(key);
                }
                _dict.Add(key, value);
            }
        }

        public bool ContainsKey(string key)
        {
            lock (_dict)
            {
                return _dict.ContainsKey(key);
            }
        }
    }
}