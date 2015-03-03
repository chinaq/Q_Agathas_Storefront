using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agathas.Storefront.Infrastructure.Domain
{
    /// <summary>
    /// 读写库
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TId"></typeparam>
    public interface IRepository<T, TId>:IReadOnlyRepository<T, TId> where T:IAggregateRoot
    {
        void Save(T entity);
        void Add(T entity);
        void Remove(T entity);
    }
}
