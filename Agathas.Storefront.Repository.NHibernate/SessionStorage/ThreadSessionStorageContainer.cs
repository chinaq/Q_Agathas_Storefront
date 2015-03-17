using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Collections;
using System.Threading;

namespace Agathas.Storefront.Repository.NHibernate.SessionStorage
{
    /// <summary>
    /// 桌面程序的工作单元，nhibernate中叫session
    /// </summary>
    public class ThreadSessionStorageContainer : ISessionStorageContainer
    {
        private static readonly Hashtable _nhSessions = new Hashtable();
        
        public ISession GetCurrentSession()
        {
            ISession nhSession = null;
            if(_nhSessions.Contains(GetThreadName()))
                nhSession = (ISession)_nhSessions[GetThreadName()];
            return nhSession;
        }
        
        public void Store(ISession session)
        {
            if (_nhSessions.Contains(GetThreadName()))
                _nhSessions[GetThreadName()] = session;
            else
                _nhSessions.Add(GetThreadName(), session);
        }

        private static string GetThreadName()
        {
            return Thread.CurrentThread.Name;
        }
    }
}
