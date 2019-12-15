namespace Calculator.ConsoleApp.Model.DiscountRule
{
    interface IDiscountRule
    {
        string AssignedName { get; set;}
        decimal GetNetPrice(int customerCount, string couponCode, decimal amount);
        bool IsValid(int customerCount, string couponCode, decimal amount);
    }
}
