using System;
using System.Collections.Generic;
using Calculator.ConsoleApp.Model.DiscountRule;
using Calculator.ConsoleApp.Model.Config;


namespace Calculator.ConsoleApp.Model
{
    public class DiscountHelper
    {
        public static List<IDiscountRule> GetDiscountRuleFromConfig(Discount discountConfig)
        {
            var baseNameSpace = discountConfig.BaseNameSpace;
            List<Rule> rulesConfig =  discountConfig.Rules;
            List<IDiscountRule> rules = new List<IDiscountRule>();
            foreach( var ruleConfig in rulesConfig)
            {
                var ruleClass = $"{baseNameSpace}.{ruleConfig.ClassName}";
                Type type = Type.GetType(ruleClass);
                var rule = (IDiscountRule)Activator.CreateInstance(type);
                rule.AssignedName = ruleConfig.Name;
                rules.Add(rule);
            }
            return rules;
        }
    }
}
