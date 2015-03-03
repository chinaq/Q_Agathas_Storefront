using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agathas.Storefront.Infrastructure.Querying
{
    /// <summary>
    /// 排序准则
    /// </summary>
    public class OrderByClause
    {
        public string PropertyName { get; set; }
        public bool Desc { get; set; }
    }
}
