using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Moq;
using Ninject;


using Library.Domain.Entities;
using Library.Data;
using Library.Services;
using Library.Web.Infrastructure.Concrete;
using Library.Web.Infrastructure.Abstract;

namespace Library.Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<CatalogService>().To<CatalogService>()
                .WithConstructorArgument("rpBooks", new DbRepository<Book>(new CatalogDbContext()))
                .WithConstructorArgument("rpCatalogOrder", new DbRepository<CatalogOrder>(new CatalogDbContext()))
                .WithConstructorArgument("rpAuthors", new DbRepository<Author>(new CatalogDbContext()))
                .WithConstructorArgument("rpGenres", new DbRepository<Genre>(new CatalogDbContext()));

            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>();
            kernel.Bind<IAuthProvider>().To<FormAuthProvider>();
        }
    }
}