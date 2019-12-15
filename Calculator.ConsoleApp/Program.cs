using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Calculator.ConsoleApp.Model;

namespace Calculator.ConsoleApp
{
    class Program
    {
        public IConfiguration Configuration { get; }
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfiguration config = builder.Build();
            Console.WriteLine("Hello World!");
        }
    }
}
