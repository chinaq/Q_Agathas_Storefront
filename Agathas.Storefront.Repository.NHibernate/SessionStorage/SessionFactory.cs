using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;

namespace Agathas.Storefront.Repository.NHibernate.SessionStorage
{
    /// <summary>
    /// 工作单元工厂
    /// </summary>
    public class SessionFactory
    {
        private static ISessionFactory _sessionFactory;

        /// <summary>
        /// 生成工作单元工厂
        /// </summary>
        private static void Init()
        {
            Configuration config = new Configuration();
            config.AddAssembly("Agathas.Storefront.Repository.NHibernate");
            log4net.Config.XmlConfigurator.Configure();
            config.Configure();
            _sessionFactory = config.BuildSessionFactory();
        }

        /// <summary>
        /// 获取工作单元工厂
        /// </summary>
        /// <returns></returns>
        private static ISessionFactory GetSessionFacotry()
        {
            if (_sessionFactory == null)
                Init();
            return _sessionFactory;
        }

        /// <summary>
        /// 生成新工作单元并获取
        /// </summary>
        /// <returns></returns>
        private static ISession GetNewSession()
        {
            return GetSessionFacotry().OpenSession();
        }

        /// <summary>
        /// 获取当前工作单元
        /// </summary>
        /// <returns></returns>
        public static ISession GetCurrentSession()
        {
            ISessionStorageContainer sessionStorageContainer = SessionStorageFacotry.GetStorageContainer();
            ISession currentSession = sessionStorageContainer.GetCurrentSession();
            if (currentSession == null)
            {
                currentSession = GetNewSession();
                sessionStorageContainer.Store(currentSession);
            }
            return currentSession;
        }
    }
}
