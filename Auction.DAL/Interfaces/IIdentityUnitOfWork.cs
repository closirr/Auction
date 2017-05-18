using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.DAL.Identity;

namespace Auction.DAL.Interfaces
{
    public interface IIdentityUnitOfWork:IDisposable
    {
        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }

        Task SaveAsync();
    }
}
