using System;
using Xunit;
using Calculator.ConsoleApp.Model.DiscountRule;
namespace Calculator.ConsoleAppTest.Model.DiscountRule
{
    public class Come4Pay3Test
    {
        private Come4Pay3 _rule = new Come4Pay3();
        private readonly string VALID_COUPON_CODE = "STARCARD";
        private readonly int CUSTOMER_COUNT = 4;
        [Fact]
        public void ValidTest()
        {
            Assert.True(_rule.IsValid(CUSTOMER_COUNT, VALID_COUPON_CODE, 1M ));
        }
        [Fact]
        public void InValidTest()
        {
            Assert.False(_rule.IsValid(1, VALID_COUPON_CODE, 1999 ));
            Assert.False(_rule.IsValid(CUSTOMER_COUNT, "Test", 1999 ));
        }
        [Fact]
        public void GetNetPriceReturnDiscountedAmountTest()
        {
            var netPrice = _rule.GetNetPrice(CUSTOMER_COUNT, VALID_COUPON_CODE, 1000);
            Assert.Equal(750, netPrice);
        }
    }
}
