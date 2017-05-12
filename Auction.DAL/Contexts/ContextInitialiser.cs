using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Contexts
{
    class ContextInitialiser:CreateDatabaseIfNotExists<AuctionContext>
    {
        protected override void Seed(AuctionContext db)
        {
            db.Lots.Add(new Lot { Id = 1, Name = "a", Price = 111 });
            db.Lots.Add(new Lot { Id = 2, Name = "b", Price = 211 });
            db.Lots.Add(new Lot { Id = 3, Name = "c", Price = 311 });
        }
    }
}
