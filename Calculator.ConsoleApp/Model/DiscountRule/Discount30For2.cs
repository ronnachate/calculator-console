namespace Calculator.ConsoleApp.Model.DiscountRule
{
    public class Discount30For2 : BaseDiscount, IDiscountRule
    {
        private readonly string VALID_COUPON_CODE = "STARCARD";
        private readonly int CUSTOMER_COUNT = 2;
        private readonly decimal DISCOUNT_PERCENTAGE = 30;
        public decimal GetNetPrice(int customerCount, string couponCode, decimal amount)
        {
            if( couponCode == VALID_COUPON_CODE && customerCount == CUSTOMER_COUNT )
            {
                return amount - ( (amount/100) * DISCOUNT_PERCENTAGE );
            }
            return amount;
        }
        public bool IsValid(int customerCount, string couponCode, decimal amount)
        {
            if( couponCode == VALID_COUPON_CODE && customerCount == CUSTOMER_COUNT )
            {
                return true;
            }
            return false;
        }
    }
}
