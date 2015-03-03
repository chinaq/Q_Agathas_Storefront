using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Agathas.Storefront.Infrastructure.Querying
{
    /// <summary>
    /// 单个属性的查询准则
    /// </summary>
    public class Criterion
    {
        private string _propertyName;
        private object _value;
        private CriteriaOperator _criteriaOperator;


        public Criterion(string propertyName, object value, CriteriaOperator criteriaOperator)
        {
            _propertyName = propertyName;
            _value = value;
            _criteriaOperator = criteriaOperator;
        }



        public string PropertyName
        {
            get { return _propertyName; }
        }

        public object Value
        {
            get { return _value; }
        }

        public CriteriaOperator CriteriaOperator
        {
            get { return _criteriaOperator; }
        }

        public static Criterion Create<T>(
            Expression<Func<T, object>> expression, object value, CriteriaOperator criteriaOperator)
        {
            string propertyName = PropertyNameHelper.ResolvePropertyName<T>(expression);
            Criterion myCriterion = new Criterion(propertyName, value, criteriaOperator);
            return myCriterion;
        }
    }
}
