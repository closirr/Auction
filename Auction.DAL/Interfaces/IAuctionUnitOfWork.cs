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
        IRepository<Lot> Lots { get; }
        IRepository<Category> Categories { get; }
        IRepository<Bid> Bids { get; }
        IRepository<ShippingData> ShippingDatas { get; }

        void Save();
    }
}
