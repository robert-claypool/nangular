using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace NAngular.App_Start
{
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            


            container.AddNewExtension<NAngular.UnityExtension>();
            container.AddNewExtension<NAngular.DataAccess.UnityExtension>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            return container;
        });


        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

    }
}
