using System;
using System.Linq;
namespace ObjectBuilderPractice
{
    public class Component
    {

        public string Name { get; set; }

        public string Type { get; set; }

        public bool IsSington{get;set;} = true;
        
        public string AssemblyName => TypeSplit().Last().Trim();
        
        public string ClassName => TypeSplit().First().Trim();
        
        private string[] TypeSplit()
        {
            string[] typeSplit = Type.Split(',');
            if (typeSplit.Length != 2)
            {
                throw new Exception(string.Format("sqlBuilder配置节点中，name={0}的节点type属性配置错误(正确格式：AssemblyName,ClassName)，当前type={1}", Name, Type));
            }
            return typeSplit;
        }
    }
}