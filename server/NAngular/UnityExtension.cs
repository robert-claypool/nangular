using NAngular.Services;
using NAngular.Services.Interfaces;
using Unity;
using Unity.Extension;
using DAL = NAngular.DataAccess;

namespace NAngular
{
    public class UnityExtension : UnityContainerExtension
    {
        private static IUnityContainer _container { get; set; }

        /// <summary>
        /// </summary>
        protected override void Initialize()
        {
            _container = Container;

            _container.RegisterType<IUserService, UserService>();
            _container.AddNewExtension<DAL.UnityExtension>();
        }

        public static IUnityContainer GetConfiguredContainer()
        {
            return _container;
        }
    }
}
