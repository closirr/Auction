﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.DAL.Contexts;
using Auction.DAL.Entities;
using Auction.DAL.Interfaces;
using Auction.DAL.Repositories;

namespace Auction.DAL.UnitsOfWork
{
    class AuctionUnitOfWork:IAuctionUnitOfWork
    {
        private AuctionContext db;
        private LotRepository LotRepository;
        private CategoryRepository CategoryRepository;
        private BidRepository BidRepository;
        private ShippingDataRepository ShippingDataRepository;

        public AuctionUnitOfWork(string connectionString)
        {
            User us = new User();
            us.
        }

        public IRepository<Lot> Lots
        {
            get
            {
                if (LotRepository == null)
                    LotRepository = new LotRepository(db);
                return LotRepository;
            }
        }
        public IRepository<Category> Categories
        {
            get
            {
                if (CategoryRepository == null)
                    CategoryRepository = new CategoryRepository(db);
                return CategoryRepository;
            }
        }
        public IRepository<Bid> Bids
        {
            get
            {
                if (BidRepository == null)
                    BidRepository = new BidRepository(db);
                return BidRepository;
            }
        }

        public IRepository<ShippingData> ShippingDatas
        {
            get
            {
                if (ShippingDataRepository == null)
                    ShippingDataRepository = new ShippingDataRepository(db);
                return ShippingDataRepository;
            }
        }



        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}