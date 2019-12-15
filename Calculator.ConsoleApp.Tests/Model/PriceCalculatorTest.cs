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
            bestRule = _calculator.GetBestRule(2, "Test", 1000 );
            Assert.Equal("Discount 10%", bestRule.Name);
            Assert.Equal(1800, bestRule.Price);
        }
        [Fact]
        public void MatchDiscount30Test()
        {
            var bestRule = _calculator.GetBestRule(2, "STARCARD", 1000 );
            Assert.Equal("Discount 30% for 2 person", bestRule.Name);
            Assert.Equal(1400, bestRule.Price);
        }
        [Fact]
        public void MatchCome4Pay3Test()
        {
            var bestRule = _calculator.GetBestRule(4, "STARCARD", 250 );
            Assert.Equal("Come 4 Pay 3", bestRule.Name);
            Assert.Equal(750, bestRule.Price);
        }
                [Fact]
        public void MatchDiscount25Test()
        {
            var bestRule = _calculator.GetBestRule(1, "STARCARD", 3000 );
            Assert.Equal("Discount 25%", bestRule.Name);
            Assert.Equal(2250, bestRule.Price);
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
                    new Rule { Name = "Discount 30% for 2 person", ClassName = "Discount30For2"},
                    new Rule { Name = "Come 4 Pay 3", ClassName = "Come4Pay3"},
                    new Rule { Name = "Discount 25%", ClassName = "Discount25"}
                }
            };
        }
    }
}
