using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using UnityInject.Models;
using Microsoft.Practices.Unity;

namespace UnityInject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterDependency();
        }

        private static UnityContainer _Container;
        public static UnityContainer Container
        {
            get
            {
                if (_Container == null)
                {
                    _Container = new UnityContainer();
                }
                return _Container;
            }
        }

        protected void RegisterDependency()
        {
            Container.RegisterType<ITest, Test>();
            //Container.RegisterType(typeof(ITest), typeof(Test));
            Container.RegisterType<IComputer,Computer>();
            Container.RegisterType<ITest, Test2>("test2");
            DependencyResolver.SetResolver(new MyDIResolver(Container));
        }
    }
}
