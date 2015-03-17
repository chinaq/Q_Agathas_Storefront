using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Agathas.Storefront.Repository.NHibernate.SessionStorage
{
    /// <summary>
    /// 工作单元保持器的工厂
    /// </summary>
    public static class SessionStorageFacotry
    {
        private static ISessionStorageContainer _nhSessionStorageContainer;

        public static ISessionStorageContainer GetStorageContainer()
        {
            if (_nhSessionStorageContainer == null)
            {
                if (HttpContext.Current == null)
                    _nhSessionStorageContainer = new ThreadSessionStorageContainer();
                else
                    _nhSessionStorageContainer = new HttpSessionContainer();
            }
            return _nhSessionStorageContainer;
        }
    }
}
