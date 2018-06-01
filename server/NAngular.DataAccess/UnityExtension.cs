using DM = NAngular.DataAccess.DataMapper;
using NAngular.DataAccess.Repositories.Interfaces;
using NAngular.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Extension;

namespace NAngular.DataAccess
{
    public class UnityExtension : UnityContainerExtension
    {
        private static IUnityContainer _container { get; set; }

        /// <summary>
        /// 
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
