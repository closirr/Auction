using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.DAL.Interfaces;
using Auction.DAL.UnitsOfWork;
using AutoMapper;
using Ninject.Modules;

namespace Auction.BLL.Infrastructure
{
    public class ServiceModule:NinjectModule
    {
        private string connectionString;

        public ServiceModule(string conString)
        {
            connectionString = conString;
        }

        public override void Load()
        {
            Bind<IAuctionUnitOfWork>().To<AuctionUnitOfWork>().WithConstructorArgument(connectionString);
            Bind<IIdentityUnitOfWork>().To<IdentityUnitOfWork>().WithConstructorArgument(connectionString);

        }
    }
}
