namespace Calculator.ConsoleApp.Model.DiscountRule
{
    public interface IDiscountRule
    {
        string AssignedName { get; set;}
        decimal GetNetPrice(int customerCount, string couponCode, decimal amount);
        bool IsValid(int customerCount, string couponCode, decimal amount);
    }
}
