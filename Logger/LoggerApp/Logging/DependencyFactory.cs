using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace LoggerApp.Logging
{
    public class DependencyFactory
    {
        private static IUnityContainer _container;
                
        public static IUnityContainer Container
        {
            get
            {
                return _container;
            }
            private set
            {
                _container = value;
            }
        }

        static DependencyFactory()
        {
            var container = new UnityContainer();

            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            if (section != null)
            {
                section.Configure(container);
            }
            _container = container;
        }

        public static T Resolve<T>()
        {
            T ret = default(T);

            ret = Container.Resolve<T>();

            return ret;
        }

        public static T Resolve<T>(string dependencyName)
        {
            T ret = default(T);
            ret = Container.Resolve<T>(dependencyName);

            return ret;
        }
    }
}
