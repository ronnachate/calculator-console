using System;
using System.Collections.Generic;
using Xunit;
using Calculator.ConsoleApp.Model;
using Calculator.ConsoleApp.Model.Config;
using Calculator.ConsoleApp.Model.DiscountRule;

namespace Calculator.ConsoleAppTest.Model
{
    public class PriceCalculatorTest
    {
        PriceCalculator _calculator;
        public PriceCalculatorTest()
        {
            var discountConfig = GetTestDiscountConfig();
            _calculator = new PriceCalculator(discountConfig);
        }
        [Fact]
        public void MatchDiscount10Test()
        {
            var bestRule = _calculator.GetBestRule(1, "DIS10", 1000 );
            Assert.Equal("Discount 10%", bestRule.Name);
            Assert.Equal(900, bestRule.Price);
            bestRule = _calculator.GetBestRule(2, "Test", 2000 );
            Assert.Equal("Discount 10%", bestRule.Name);
            Assert.Equal(1800, bestRule.Price);
        }
        [Fact]
        public void MatchDiscount30Test()
        {
            var bestRule = _calculator.GetBestRule(2, "STARCARD", 2000 );
            Assert.Equal("Discount 30%", bestRule.Name);
            Assert.Equal(1400, bestRule.Price);
        }
        [Fact]
        public void NotMatchAnyRuleTest()
        {
            var bestRule = _calculator.GetBestRule(1, "NONE", 1900 );
            Assert.True( string.IsNullOrEmpty(bestRule.Name));
            Assert.Equal(1900, bestRule.Price);
        }

        private Discount GetTestDiscountConfig()
        {
            return new Discount
            {
                BaseNameSpace = "Calculator.ConsoleApp.Model.DiscountRule",
                Rules =  new List<Rule>
                {
                    new Rule { Name = "Discount 10%", ClassName = "Discount10"},
                    new Rule { Name = "Discount 30%", ClassName = "Discount30For2"}
                }
            };
        }
    }
}
