using System.Linq;
using System.Collections.Generic;
using Xunit;
using Calculator.ConsoleApp.Model;
using Calculator.ConsoleApp.Model.Config;
using Calculator.ConsoleApp.Model.DiscountRule;

namespace Calculator.ConsoleAppTest.Model
{
    public class DiscountHelperTest
    {
        [Fact]
        public void GetValidConfigTest()
        {
            var _config =  GetTestDiscountConfig();
            var rules = DiscountHelper.GetDiscountRuleFromConfig(_config);
            Assert.IsType<List<IDiscountRule>>(rules);
            Assert.Equal(4, rules.Count);
            var firstRule = rules.First();
            Assert.IsType<Discount10>(firstRule);
            Assert.Equal("Discount 10%", firstRule.AssignedName);
        }

        private Discount GetTestDiscountConfig()
        {
            return new Discount
            {
                BaseNameSpace = "Calculator.ConsoleApp.Model.DiscountRule",
                Rules =  new List<Rule>
                {
                    new Rule { Name = "Discount 10%", ClassName = "Discount10"},
                    new Rule { Name = "Discount 30% for 2 person", ClassName = "Discount30For2"},
                    new Rule { Name = "Come 4 Pay 3", ClassName = "Come4Pay3"},
                    new Rule { Name = "Discount 25%", ClassName = "Discount25"}
                }
            };
        }
    }
}
