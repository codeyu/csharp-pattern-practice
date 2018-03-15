using System;
using System.Reflection;
using System.Linq;
namespace ObjectBuilderPractice
{
    public class BaseFactory
    {
        private readonly ObjectBuilderConfig _objectBuilderConfig;
        protected BaseFactory(ObjectBuilderConfig objectBuilderConfig) => _objectBuilderConfig = objectBuilderConfig;


        protected TResult GetConcreateComponent<TResult>(ObjectBuilderContext context, ComponentType componentType) where TResult : class
        {
            var options = context.Options;
            //优先级1context
            if (options.Keys.Contains("queryEngine"))
            {
                var componentName = options["queryEngine"];
                
                    var component = GetComponentNeeded(componentName,
                        string.Format("Options中QueryEngine指定的{0}:{1}没有在配置文件中找到相应的配置", componentType, componentName), componentType);
                    return CreateComponent<TResult>(component);
                
            }

            //优先级2
            var platformNeed = options["platform"];
            if (platformNeed != null)
            {
                var component = GetComponentNeededByPlatform(platformNeed,
                    string.Format("Options中指定的platform:{0}没有在配置文件中找到相应的配置", platformNeed), componentType);
                return CreateComponent<TResult>(component);
            }

            //优先级3
            platformNeed = "DefaultPlatform";
            if (platformNeed == null)
                throw new Exception(string.Format("{0}Factory工厂没有发现任何{0}描述信息以供生产", componentType));
            {
                var component = GetComponentNeededByPlatform(platformNeed.ToString(),
                    string.Format("元数据中指定的platform:{0}没有在配置文件中找到相应的配置", platformNeed), componentType);
                return CreateComponent<TResult>(component);
            }

        }

        private Component GetComponentNeededByPlatform(string platformNeed, string errorMsg, ComponentType componentType)
        {
            var platform = _objectBuilderConfig.Platforms.FirstOrDefault(p => p.Name == platformNeed.ToString());
            if (platform == null)
            {
                throw new Exception(errorMsg);
            }

            string componentName;
            switch (componentType)
            {
                case ComponentType.TreeBuilder:
                    componentName = platform.TreeBuilder;
                    break;
                case ComponentType.SqlGenerator:
                    componentName = platform.SqlGenerator;
                    break;
                case ComponentType.SqlExecutor:
                    componentName = platform.SqlExecutor;
                    break;
                default:
                    throw new ArgumentException(string.Format("Dost not support the specified ComponentType.({0})",
                           componentType));
            }

            return GetComponentNeeded(componentName,
                string.Format("platform:{0}设置的{1}:{2}没有在配置文件中找到相应的配置",
                        platformNeed, componentType, componentName), componentType);
        }


        private Component GetComponentNeeded(string componentName, string errorMsg, ComponentType componentType)
        {
            Component component;
            switch (componentType)
            {
                case ComponentType.TreeBuilder:
                    component = _objectBuilderConfig.TreeBuilders.FirstOrDefault(t => t.Name == componentName);
                    break;
                case ComponentType.SqlGenerator:
                    component = _objectBuilderConfig.SqlGenerators.FirstOrDefault(t => t.Name == componentName);
                    break;
                case ComponentType.SqlExecutor:
                    component = _objectBuilderConfig.SqlExecutors.FirstOrDefault(t => t.Name == componentName);
                    break;
                default:
                    throw new ArgumentException(string.Format("Dost not support the specified ComponentType.({0})",
                           componentType));
            }
            if (component == null)
            {
                throw new Exception(errorMsg);
            }
            return component;
        }


        private static TResult CreateComponent<TResult>(Component component) where TResult : class
        {
            TResult result;
            if (component.IsSington)
            {
                //以类全名为key进行缓存
                var singtonStorage = SingtonStorage.Instance;
                if (singtonStorage.ContainsKey(component.ClassName))
                {
                    result = singtonStorage.Get(component.ClassName) as TResult;
                }
                else
                {
                    //否则反射对象，存储
                    result = Assembly.Load(component.AssemblyName).CreateInstance(component.ClassName) as TResult;
                    singtonStorage.Set(component.ClassName, result);
                }
            }
            else
            {
                result = Assembly.Load(component.AssemblyName).CreateInstance(component.ClassName) as TResult;
            }
            if (result == null)
            {
                throw new Exception($"{nameof(result)} is null");
            }
            return result;
        }
    }
}
