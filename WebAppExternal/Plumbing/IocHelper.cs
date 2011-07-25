using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;

namespace CCE.WebConnection.WebAppExternal.Plumbing
{
    public static class IocHelper
    {
        private static IWindsorContainer _container = null;
        private static object _syncObject = new object();

        public static IWindsorContainer Container()
        {
            if (_container == null)
            {
                lock (_syncObject)
                {
                    if (_container == null)
                    {
                        _container = new WindsorContainer(new XmlInterpreter());
                    }
                }
            }

            return _container;
        }

        public static void DisposeContainer()
        {
            if (_container != null)
            {
                lock (_syncObject)
                {
                    if (_container != null)
                    {
                        _container.Dispose();
                        _container = null;
                    }
                }
            }
        }
    }
}