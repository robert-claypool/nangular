using NAngular.DataAccess.Repositories;
using NAngular.DataAccess.Repositories.Interfaces;
using Unity;
using Unity.Extension;
using DM = NAngular.DataAccess.DataMapper;

namespace NAngular.DataAccess
{
    public class UnityExtension : UnityContainerExtension
    {
        private static IUnityContainer _container { get; set; }

        /// <summary>
        /// </summary>
        protected override void Initialize()
        {
            _container = Container;
            _container.RegisterType<DM.IDataMapper, DM.DataMapper>();
            _container.RegisterType<IUserRepository, UserRepository>();
        }

        public static IUnityContainer GetConfiguredContainer()
        {
            return _container;
        }
    }
}
