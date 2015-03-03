using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agathas.Storefront.Infrastructure.Querying
{
    /// <summary>
    /// 查询类的聚合根
    /// </summary>
    public class Query
    {
        private IList<Query> _subQueries = new List<Query>();
        private IList<Criterion> _criteria = new List<Criterion>();

        public IEnumerable<Criterion> Criteria
        {
            get { return _criteria; }
        }

        public IEnumerable<Query> SubQueries
        {
            get { return _subQueries; }
        }

        public void Add(Criterion criterion)
        {
            _criteria.Add(criterion);
        }

        public QueryOperator QueryOperator { get; set; }

        public OrderByClause OrderByProperty { get; set; }
    }
}
