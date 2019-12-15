using System;
using Xunit;
using Calculator.ConsoleApp.Model.DiscountRule;
namespace Calculator.ConsoleAppTest.Model.DiscountRule
{
    public class Discount25Test
    {
        private Discount25 _rule = new Discount25();
        private readonly decimal MINIMUM_AMOUNT = 2500;
        [Fact]
        public void ValidWithMinimumAmountTest()
        {
            Assert.True(_rule.IsValid(1, "Test", MINIMUM_AMOUNT ));
        }
        [Fact]
        public void InValidTest()
        {
            Assert.False(_rule.IsValid(1, "Test", 1999 ));
        }
        [Fact]
        public void GetNetPriceReturnDiscountedAmountTest()
        {
            var netPrice = _rule.GetNetPrice(1, "Test", 3000);
            Assert.Equal(2250, netPrice);
        }
        [Fact]
        public void GetNetPriceReturnSameForInvalidInputAmountTest()
        {
            var netPrice = _rule.GetNetPrice(1, "Test", 1000);
            Assert.Equal(1000, netPrice);
        }
    }
}
