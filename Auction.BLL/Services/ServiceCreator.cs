using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.BLL.Intefraces;
using Auction.DAL.UnitsOfWork;

namespace Auction.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new IdentityUnitOfWork(connection), new AuctionUnitOfWork(connection));
        }
    }
}
