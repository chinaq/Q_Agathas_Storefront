using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace Agathas.Storefront.Repository.NHibernate.SessionStorage
{
    /// <summary>
    /// 工作单元保持器的接口
    /// </summary>
    public interface ISessionStorageContainer
    {
        /// <summary>
        /// 获取工作单元
        /// </summary>
        /// <returns></returns>
        ISession GetCurrentSession();

        /// <summary>
        /// 存储工作单元
        /// </summary>
        /// <param name="session"></param>
        void Store(ISession session);
    }
}
