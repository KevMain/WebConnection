using System;
using System.Linq;
using System.Web.Mvc;
using Castle.Core;
using System.Web.Routing;

namespace CCE.WebConnection.WebAppExternal.Plumbing
{
    public class IocControllerFactory : DefaultControllerFactory
    {
        public IocControllerFactory()
        {
            var controllerTypes = from t in AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes())
                                  where typeof(IController).IsAssignableFrom(t)
                                  select t;

            foreach (Type type in controllerTypes)
            {
                IocHelper.Container().AddComponentLifeStyle(type.FullName, type, LifestyleType.Transient);
            }
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType != null)
            {
                return (IController)IocHelper.Container().Resolve(controllerType);
            }

            return base.GetControllerInstance(requestContext, controllerType);
        }
    }
}