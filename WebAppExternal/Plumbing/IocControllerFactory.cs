using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using CCE.WebConnection.BL;
using Castle.Core;
using System.Web.Routing;
using Castle.MicroKernel.Registration;

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
                IoCManager.Container().Register(Component.For(type).Named(type.FullName).LifeStyle.Is(LifestyleType.Transient));
            }

            IoCManager.Container().Register(Component.For<IMappingEngine>().Instance(Mapper.Engine));
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType != null)
            {
                return (IController)IoCManager.Container().Resolve(controllerType);
            }

            return base.GetControllerInstance(requestContext, controllerType);
        }
    }
}