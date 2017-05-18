﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auction.BLL.Intefraces;
using Auction.BLL.Services;
using AutoMapper;
using Ninject;

namespace Auction.Util
{
    public class NinjectDependencyResolver:IDependencyResolver
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
            kernel.Bind<ICategoryService>().To<CategoryService>();
            kernel.Bind<ILotService>().To<LotService>();
            //kernel.Bind<IUserService>().To<UserService>();
        }

    }
}