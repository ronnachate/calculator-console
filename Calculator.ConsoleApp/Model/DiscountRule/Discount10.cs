namespace Calculator.ConsoleApp.Model.DiscountRule
{
    public class Discount10 : BaseDiscount, IDiscountRule
    {
        private readonly string VALID_COUPON_CODE = "DIS10";
        private readonly decimal MINIMUM_AMOUNT = 2000;
        private readonly decimal DISCOUNT_PERCENTAGE = 10;
        public decimal GetNetPrice(int customerCount, string couponCode, decimal amount)
        {
            if( couponCode == VALID_COUPON_CODE || amount >= MINIMUM_AMOUNT )
            {
                return amount - ( (amount/100) * DISCOUNT_PERCENTAGE );
            }
            return amount;
        }
        public bool IsValid(int customerCount, string couponCode, decimal amount)
        {
            if( couponCode == VALID_COUPON_CODE || amount >= MINIMUM_AMOUNT )
            {
                return true;
            }
            return false;
        }
    }
}
