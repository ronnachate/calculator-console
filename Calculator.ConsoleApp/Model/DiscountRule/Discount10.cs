namespace Calculator.ConsoleApp.Model.DiscountRule
{
    public class Discount10 : IDiscountRule
    {
        private readonly string VALID_COUPON_CODE = "DIS10";
        private readonly decimal MINIMUM_AMOUNT = 2000;
        public decimal GetNetPrice(string couponCode, decimal amount)
        {
            return 0;
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
