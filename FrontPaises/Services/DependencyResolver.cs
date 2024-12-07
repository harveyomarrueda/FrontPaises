using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaisesMVC.Controllers;

namespace PaisesMVC.Services
{
    public class DependencyResolver : IDependencyResolver
    {
        //readonly IServiceLocator _serviceLocator;

        //public DependencyResolver(IServiceLocator serviceLocator)
        //{
        //    _serviceLocator = serviceLocator;
        //}

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(HomeController))
                return new HomeController(new serviceAPI());
            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Enumerable.Empty<object>();
        }
    }
}