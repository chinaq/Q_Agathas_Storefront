using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Agathas.Storefront.Infrastructure.Querying;
using NHibernate.Criterion;

namespace Agathas.Storefront.Repository.NHibernate.Repositories
{
    public static class QueryTranslator
    {
        /// <summary>
        /// 将自定义的查询语句转换成NHibernate的查询语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="criteria"></param>
        /// <returns>返回的就是参数criteria被修改后的值</returns>
        public static ICriteria TranslateIntoNHQuery<T>(this Query query, ICriteria criteria)
        {
            BuildQueryFrom(query, criteria);
            if (query.OrderByProperty != null)
                criteria.AddOrder(new Order(query.OrderByProperty.PropertyName, !query.OrderByProperty.Desc));
            return criteria;
        }

        private static void BuildQueryFrom(Query query, ICriteria criteria)
        {
            IList<ICriteria> criterions = new List<ICriteria>();

            //如果该查询中的属性要求不为空，则处理查询中的每个属性要求
            if (query.Criteria != null)
            {
                foreach (Criterion c in query.Criteria)
                {
                    ICriteria criterion;
                    switch (c.CriteriaOperator)
                    {
                        case CriteriaOperator.Equal:
                            criterion = (ICriteria)Expression.Eq(c.PropertyName, c.Value);
                            break;
                        case CriteriaOperator.LesserThanOrEqual:
                            criterion = (ICriteria)Expression.Le(c.PropertyName, c.Value);
                            break;
                        default:
                            throw new ApplicationException("No operator defined");
                    }
                    criterions.Add(criterion);
                }
            }

            //使用And连接本级criterions，或者使用or连接本级
            if (query.QueryOperator == QueryOperator.And) {
                Conjunction andSubQuery = Expression.Conjunction();
                foreach (ICriterion criterion in criterions)
                {
                    andSubQuery.Add(criterion);
                }
                criteria.Add(andSubQuery);
            }
            else
            {
                Disjunction orSubQuery = Expression.Disjunction();
                foreach (ICriterion criterion in criterions)
                {
                    orSubQuery.Add(criterion);
                }
                criteria.Add(orSubQuery);
            }

            //添加子查询的内容
            foreach (Query sub in query.SubQueries)
            {
                BuildQueryFrom(sub, criteria);
            }
        }
    }
}
