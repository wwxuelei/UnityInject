using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnityInject.Models;

namespace UnityInject.Controllers
{
    
    public class HomeController : Controller
    {
        [Dependency("test2")]
        public ITest testsx { get; set; }
        private ITest test{get;set;}
        public HomeController() { }

        [InjectionConstructor]        
        public HomeController(ITest test) {
            this.test = test;
        }
        public ActionResult Index()
        {
            return Content(string.Format("{0}<br>{1}", test.getName(), testsx.getName()));
            //return Content(test.getName());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}