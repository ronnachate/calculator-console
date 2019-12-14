namespace Calculator.ConsoleApp.Model.DiscountRule
{
    public class Discount10 : IDiscountRule
    {
        public decimal GetNetPrice(string couponCode, decimal amount)
        {
            return 0;
        }
        public bool IsValid(int customerCount, string couponCode, decimal amount)
        {
            return true;
        }
    }
}
