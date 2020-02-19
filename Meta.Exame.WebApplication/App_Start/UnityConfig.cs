using Meta.Exame.WebApplication.Service;
using System;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
namespace Meta.Exame.WebApplication
{
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion
        public static void RegisterTypes(IUnityContainer container)
        {
        }
        public static void RegistraComponentes()
        {
            var service = new UnityContainer();
            service.RegisterType<MarcaService>();
            service.RegisterType<ModeloService>();
            service.RegisterType<SeguradoService>();
            service.RegisterType<VeiculoService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(service));
        }
    }
}