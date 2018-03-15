using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace ObjectBuilderPractice
{
    public class ObjectBuilderConfig
    {
        /// <summary>
        /// TreeBuilder集合
        /// </summary>
        public List<Component> TreeBuilders { get; set; }

        /// <summary>
        /// SqlGenerator集合
        /// </summary>
        public List<Component> SqlGenerators { get; set; }

        /// <summary>
        /// SqlExecutor集合
        /// </summary>
        public List<Component> SqlExecutors { get; set; }

        /// <summary>
        /// Platform集合
        /// </summary>
        public List<Platform> Platforms { get; set; }

        public ObjectBuilderConfig()
        {
        }
        
    }
}
