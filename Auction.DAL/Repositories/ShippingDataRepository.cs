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
    public class ShippingDataRepository : IRepository<ShippingData, string>
    {
        private AuctionContext db;
        public ShippingDataRepository(AuctionContext _db)
        {
            db = _db;
        }
        public IQueryable<ShippingData> GetAll()
        {

            return db.ShippingDatas;
        }

        public ShippingData Get(string id)
        {
            return db.ShippingDatas.Find(id);
        }

        public void Create(ShippingData item)
        {
            db.ShippingDatas.Add(item);
        }

        public void Update(ShippingData item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(string id)
        {
            ShippingData item = db.ShippingDatas.Find(id);
            if (item != null)
                db.ShippingDatas.Remove(item);
        }
    }
}
