using System;
using System.Linq;
using System.Collections.Generic;
using Calculator.ConsoleApp.Model.DiscountRule;
using Calculator.ConsoleApp.Model.Config;


namespace Calculator.ConsoleApp.Model
{
    public class PriceCalculator
    {
        string AssignedName { get; set;}
        private List<IDiscountRule> _rules = new List<IDiscountRule>();
        private string _baseNameSpace;
        public PriceCalculator(Discount discountConfig)
        {
            _baseNameSpace = discountConfig.BaseNameSpace;
            InitDiscountRule(discountConfig.Rules);
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
        private void InitDiscountRule(List<Rule> rulesConfig)
        {
            foreach( var ruleConfig in rulesConfig)
            {
                var ruleClass = $"{_baseNameSpace}.{ruleConfig.ClassName}";
                Type type = Type.GetType(ruleClass);
                var rule = (IDiscountRule)Activator.CreateInstance(type);
                rule.AssignedName = ruleConfig.Name;
                _rules.Add(rule);
            } 
        }
    }
}
