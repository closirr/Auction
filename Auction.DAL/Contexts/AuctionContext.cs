using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Contexts
{
    class AuctionContext:DbContext
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

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
