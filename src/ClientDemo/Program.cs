using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using ObjectBuilderPractice;

namespace ClientDemo
{
    class Program
    {
        private static IConfiguration Configuration { get; set; }
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            var objBuilderConfig = new ObjectBuilderConfig();
            Configuration.GetSection(nameof(ObjectBuilderConfig)).Bind(objBuilderConfig);
            IObjectProvider provider = new ConfigProvider("2");
            var manager = new ObjectBuilderManager(provider, objBuilderConfig);
            manager.Execute();
            Console.WriteLine($"option1 = {Configuration["Option1"]}");
            Console.WriteLine($"option2 = {Configuration["option2"]}");
            Console.WriteLine(
                $"suboption1 = {Configuration["subsection:suboption1"]}");
            Console.WriteLine();

            Console.WriteLine("Wizards:");
            Console.Write($"{Configuration["wizards:0:Name"]}, ");
            Console.WriteLine($"age {Configuration["wizards:0:Age"]}");
            Console.Write($"{Configuration["wizards:1:Name"]}, ");
            Console.WriteLine($"age {Configuration["wizards:1:Age"]}");
            Console.WriteLine();

            Console.WriteLine("Press a key...");
            Console.ReadKey();
        }
    }
}
