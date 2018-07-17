using Ninject;
using OP.Repository;
using OP.Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OP.Brochure.Ninject
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext
            requestContext, Type controllerType)
        {

            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<IOptionsProductRepository>().To<OptionsProductRepository>();
            ninjectKernel.Bind<IBrochureRepository>().To<BrochureRepository>();
            ninjectKernel.Bind<IGuestBookRepository>().To<GuestBookRepository>();
            //put bindings here
        }
    }
}