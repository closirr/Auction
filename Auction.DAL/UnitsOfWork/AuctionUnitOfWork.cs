using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.DAL.Contexts;
using Auction.DAL.Entities;
using Auction.DAL.Interfaces;
using Auction.DAL.Repositories;

namespace Auction.DAL.UnitsOfWork
{
    public class AuctionUnitOfWork:IAuctionUnitOfWork
    {
        private AuctionContext db;
        private LotRepository LotRepository;
        private CategoryRepository CategoryRepository;
        private BidRepository BidRepository;
        private ShippingDataRepository ShippingDataRepository;
        private IUserProfileManager UserProfileRepository;


        public AuctionUnitOfWork(string connectionString)
        {
            db = new AuctionContext(connectionString);
        }

        public IRepository<Lot,string> Lots
        {
            get
            {
                if (LotRepository == null)
                    LotRepository = new LotRepository(db);
                return LotRepository;
            }
        }
        public IRepository<Category, int> Categories
        {
            get
            {
                if (CategoryRepository == null)
                    CategoryRepository = new CategoryRepository(db);
                return CategoryRepository;
            }
        }
        public IRepository<Bid, string> Bids
        {
            get
            {
                if (BidRepository == null)
                    BidRepository = new BidRepository(db);
                return BidRepository;
            }
        }

        public IRepository<ShippingData, string> ShippingDatas
        {
            get
            {
                if (ShippingDataRepository == null)
                    ShippingDataRepository = new ShippingDataRepository(db);
                return ShippingDataRepository;
            }
        }

        public IUserProfileManager UserProfile
        {
            get
            {
                if (UserProfileRepository == null)
                    UserProfileRepository = new UserProfileRepository(db);
                return UserProfileRepository;
            }
        }





        public void Save()
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw new Exception(ex.Message + ex.EntityValidationErrors);
            }
    }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
