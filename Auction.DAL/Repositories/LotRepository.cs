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
    public class LotRepository:IRepository<Lot, string>
    {
        private AuctionContext db;
        public LotRepository(AuctionContext _db)
        {
            db = _db;
        }
        public IQueryable<Lot> GetAll()
        {

            return db.Lots;
        }

        public Lot Get(string id)
        {
            return db.Lots.Find(id);
        }

        public void Create(Lot item)
        {
            db.Lots.Add(item);

        }

        public void Update(Lot item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(string id)
        {
            Lot item = db.Lots.Find(id);
            if (item != null)
                db.Lots.Remove(item);
        }
    }
}
