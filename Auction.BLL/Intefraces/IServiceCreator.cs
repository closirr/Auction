using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.BLL.Intefraces
{
    public interface  IServiceCreator
    {
        IUserService CreateUserService(string connection);
    }
}
