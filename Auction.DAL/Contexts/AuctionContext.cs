using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.DAL.Entities;

namespace Auction.DAL.Contexts
{
    public class AuctionContext:DbContext
    {
        public AuctionContext()
        {
        }

        public AuctionContext(string connectionString)
            : base(connectionString)
        {
            //string path = ConfigurationSettings.AppSettings["DataDirectory"];
            //AppDomain.CurrentDomain.SetData("DataDirectory", path);

        }
        static AuctionContext()
        {
            System.Data.Entity.Database.SetInitializer((new ContextInitialiser()));
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<ShippingData> ShippingDatas { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
