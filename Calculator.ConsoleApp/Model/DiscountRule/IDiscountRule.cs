namespace Calculator.ConsoleApp.Model.DiscountRule
{
    interface IDiscountRule
    {
        decimal GetNetPrice(string couponCode, decimal amount);
        bool IsValid(int customerCount, string couponCode, decimal amount);
    }
}
