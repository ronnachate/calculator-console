using System;
using Xunit;
using Calculator.ConsoleApp.Model.DiscountRule;
namespace Calculator.ConsoleAppTest.Model.DiscountRule
{
    public class Discount10Test
    {
        private Discount10 _rule = new Discount10();
        private readonly string VALID_COUPON_CODE = "DIS10";
        private readonly decimal MINIMUM_AMOUNT = 2000;
        [Fact]
        public void ValidWithCouponTest()
        {
            Assert.True(_rule.IsValid(1, VALID_COUPON_CODE, 1M ));
        }
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
    }
}
