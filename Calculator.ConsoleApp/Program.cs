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
            //due to  important part is Price calculator model, so skip input args and validation here
            //assume all data is correct and invalid data will be reject before this
            Console.WriteLine("-- Start Calculate input");
            Console.WriteLine("Test with 1 person, code DIS10, price 500");
            var bestRule = calculator.GetBestRule(1, "DIS10", 500 );
            if( !string.IsNullOrEmpty(bestRule.Name))
            {
                Console.WriteLine( "-Match with promotion : " + bestRule.Name.ToString());
                Console.WriteLine("-Amount : " + bestRule.Price.ToString());
            }
            Console.WriteLine("Test with 1 person, code STARCARD, price 2000");
            bestRule = calculator.GetBestRule(1, "STARCARD", 2000 );
            if( !string.IsNullOrEmpty(bestRule.Name))
            {
                Console.WriteLine("-Match with promotion : " + bestRule.Name.ToString());
                Console.WriteLine("-Amount : " + bestRule.Price.ToString());
            }
            Console.WriteLine("Test with 2 person, code DIS10, price 1500");
            bestRule = calculator.GetBestRule(2, "DIS10", 1500 );
            if( !string.IsNullOrEmpty(bestRule.Name))
            {
                Console.WriteLine("-Match with promotion : " + bestRule.Name.ToString());
                Console.WriteLine("-Amount : " + bestRule.Price.ToString());
            }
            Console.WriteLine("-- End Calculation");
        }
    }
}
