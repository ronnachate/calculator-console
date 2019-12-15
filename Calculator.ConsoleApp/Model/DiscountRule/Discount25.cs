namespace Calculator.ConsoleApp.Model.DiscountRule
{
    public class Discount25 : BaseDiscount, IDiscountRule
    {
        private readonly decimal MINIMUM_AMOUNT = 2500;
        private readonly decimal DISCOUNT_PERCENTAGE = 25;
        public decimal GetNetPrice(int customerCount, string couponCode, decimal amount)
        {
            if( IsValid(customerCount, couponCode, amount) )
            {
                return amount - ( (amount/100) * DISCOUNT_PERCENTAGE );
            }
            return amount;
        }
        public bool IsValid(int customerCount, string couponCode, decimal amount)
        {
            if( amount >= MINIMUM_AMOUNT )
            {
                return true;
            }
            return false;
        }
    }
}
