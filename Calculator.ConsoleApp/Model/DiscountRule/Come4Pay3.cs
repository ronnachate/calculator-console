﻿namespace Calculator.ConsoleApp.Model.DiscountRule
{
    public class Come4Pay3 : BaseDiscount, IDiscountRule
    {
        private readonly string VALID_COUPON_CODE = "STARCARD";
        private readonly int CUSTOMER_COUNT = 4;
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
            if( couponCode == VALID_COUPON_CODE && customerCount == CUSTOMER_COUNT )
            {
                return true;
            }
            return false;
        }
    }
}
