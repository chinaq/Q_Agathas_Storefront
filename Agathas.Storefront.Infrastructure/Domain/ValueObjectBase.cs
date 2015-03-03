using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agathas.Storefront.Infrastructure.Domain
{
    /// <summary>
    /// 值类型基础类，检验规则
    /// </summary>
    public abstract class ValueObjectBase
    {
        private List<BusinessRule> _brokenRules = new List<BusinessRule>();

        public ValueObjectBase() { }

        protected abstract void Validate();

        public void ThrowExceptionIfInvalide() {
            _brokenRules.Clear();
            Validate();
            if (_brokenRules.Count() > 0) {
                StringBuilder issues = new StringBuilder();
                foreach (BusinessRule businessRule in _brokenRules)
                    issues.AppendLine(businessRule.Rule);
                throw new ValueObjectIsInvalidException(issues.ToString());
            }
        }

        protected void AddBrokenRule(BusinessRule businessRule){
            _brokenRules.Add(businessRule);
        }
    }
}
