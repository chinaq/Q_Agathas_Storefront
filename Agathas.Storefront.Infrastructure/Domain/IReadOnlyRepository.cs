using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Querying;

namespace Agathas.Storefront.Infrastructure.Domain
{
    /// <summary>
    /// 只读库
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TId"></typeparam>
    public interface IReadOnlyRepository<T, TId> where T:IAggregateRoot
    {
        T FindBy(TId id);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindBy(Query query);
        IEnumerable<T> FindBy(Query query, int index, int count);
    }
}
