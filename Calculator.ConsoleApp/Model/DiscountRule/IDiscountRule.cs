namespace Calculator.ConsoleApp.Model.DiscountRule
{
    interface IDiscountRule
    {
        decimal GetNetPrice(int customerCount, string couponCode, decimal amount);
        bool IsValid(int customerCount, string couponCode, decimal amount);
    }
}
