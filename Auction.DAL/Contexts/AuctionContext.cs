using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Auction.DAL.Contexts
{
    public class AuctionContext: IdentityDbContext<User>
    {
        public AuctionContext()
        {
        }

        public AuctionContext(string connectionString)
            :  base(connectionString, false)
        {

        }
        static AuctionContext()
        {
            System.Data.Entity.Database.SetInitializer<AuctionContext>(null);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<ShippingData> ShippingDatas { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
