using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.DAL.Entities;

namespace Auction.DAL.Interfaces
{
    public interface IUserProfileManager:IDisposable
    {
        IQueryable<UserProfile> GetAll();
        UserProfile Get(string id);
        void Create(UserProfile item);
        void Update(UserProfile item);
        void Delete(string id);
    }
}
