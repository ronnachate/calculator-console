using System.Collections.Generic;
using Calculator.ConsoleApp.Model.DiscountRule;

namespace Calculator.ConsoleApp.Model
{
    public class PriceCalculator
    {
        private List<IDiscountRule> _rules = new List<IDiscountRule>();
        private string _baseNameSpace;
        public PriceCalculator(List<IDiscountRule> rules)
        {
            _rules = rules;
        }
        public RuleResult GetBestRule(int customerCount, string couponCode, decimal pricePerPerson)
        {
            decimal amount = customerCount * pricePerPerson;
            RuleResult bestRule = new RuleResult
            {
                Price = amount
            };

            foreach( var rule in _rules)
            {
                if( rule.IsValid(customerCount, couponCode, amount) )
                {
                    var ruleAmount = rule.GetNetPrice(customerCount, couponCode, amount);
                    if( ruleAmount < bestRule.Price)
                    {
                        bestRule = new RuleResult
                        {
                            Name = rule.AssignedName,
                            Price = ruleAmount
                        };
                    }
                }
            }
            return bestRule;
        }
    }
}
