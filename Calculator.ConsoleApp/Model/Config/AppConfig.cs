using System.Collections.Generic;

namespace Calculator.ConsoleApp.Model.Config
{
    public class AppConfig
    {
        public string BaseNameSpace { get; set; }
        public List<Rule> Rules { get; set; }
    }
}