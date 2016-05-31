using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using SportsStore.Domain.Abstract;
using Moq;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Concrete;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext,
        Type controllerType)
        {
            return controllerType == null
            ? null
            : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            // put additional bindings here
            // Mock implementation of the IProductRepository Interface
            /*Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product> {
            new Product { Name = "Football",Description="This is a Football",Category="Soccer", Price = 25 },
            new Product { Name = "Surf board",Description="This is a Surfboard",Category="Water Sports", Price = 179 },
            new Product { Name = "Running shoes",Description="This is a Sports Shoe",Category="Footwear", Price = 95 }
            }.AsQueryable());
            ninjectKernel.Bind<IProductRepository>().ToConstant(mock.Object);*/
            ninjectKernel.Bind<IProductRepository>().To<EFProductRepository>();
        }
    }
}
