using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.DAL.Entities;

namespace Auction.DAL.Interfaces
{
    public interface IAuctionUnitOfWork : IDisposable
    {
        IRepository<Lot,int> Lots { get; }
        IRepository<Category,int> Categories { get; }
        IRepository<Bid, int> Bids { get; }
        IRepository<ShippingData, string> ShippingDatas { get; }
        IUserProfileManager UserProfile { get; }

        void Save();
    }
}
