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
        IRepository<Lot,string> Lots { get; }
        IRepository<Category,int> Categories { get; }
        IRepository<Bid, string> Bids { get; }
        IRepository<ShippingData, string> ShippingDatas { get; }

        void Save();
    }
}
