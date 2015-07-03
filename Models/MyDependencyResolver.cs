using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UnityInject.Models
{
    public class MyDependencyResolver : IDependencyResolver
    {
        #region IDependencyResolver 成员

        /// <summary>
        /// 依赖注入容器
        /// </summary>
        private UnityContainer _unityContainer;

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="aUnityContainer">依赖注入容器</param>
        public MyDependencyResolver(UnityContainer aUnityContainer)
        {
            _unityContainer = aUnityContainer;
        }

        public object GetService(Type aServiceType)
        {
            try
            {
                return _unityContainer.Resolve(aServiceType);
            }
            catch
            {
                /// 按微软的要求，此方法，在没有解析到任何对象的情况下，必须返回 null，必须这么做！！！！
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type aServiceType)
        {
            try
            {
                return _unityContainer.ResolveAll(aServiceType);
            }
            catch
            {
                /// 按微软的要求，此方法，在没有解析到任何对象的情况下，必须返回空集合，必须这么做！！！！
                return new List<object>();
            }
        }

        #endregion
    }
}