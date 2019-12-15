using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Calculator.ConsoleApp.Model;
using Calculator.ConsoleApp.Model.Config;

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
            var discountConfig = new Discount();
            config.GetSection("Discount").Bind(discountConfig);
            var calculator = new PriceCalculator(discountConfig);
            var bestRule = calculator.GetBestRule(2, "STARCARD", 2000 );
            if( !string.IsNullOrEmpty(bestRule.Name))
            {
                Console.WriteLine( "Match with promotion : " + bestRule.Name.ToString());
                Console.WriteLine( "Amount : " + bestRule.Price.ToString());
            }
            else
            {
                Console.WriteLine( "Amount : " + bestRule.Price.ToString());
            }
        }
    }
}
