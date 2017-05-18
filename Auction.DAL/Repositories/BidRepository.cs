using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.DAL.Contexts;
using Auction.DAL.Entities;
using Auction.DAL.Interfaces;

namespace Auction.DAL.Repositories
{
    public class BidRepository : IRepository<Bid, int>
    {
        private AuctionContext db;
        public BidRepository(AuctionContext _db)
        {
            db = _db;
        }
        public IQueryable<Bid> GetAll()
        {

            return db.Bids;
        }

        public Bid Get(int id)
        {
            return db.Bids.Find(id);
        }

        public void Create(Bid item)
        {
            db.Bids.Add(item);
        }

        public void Update(Bid item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Bid item = db.Bids.Find(id);
            if (item != null)
                db.Bids.Remove(item);
        }
    }
}
