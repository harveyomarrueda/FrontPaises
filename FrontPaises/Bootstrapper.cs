using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using PaisesMVC.Services;

namespace PaisesMVC
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<IServiceAPI, serviceAPI>();   //Registrando la dependencia (INYECCION) al Contenedor.

            // e.g. container.RegisterType<ITestService, TestService>();            

            return container;
        }
    }
}