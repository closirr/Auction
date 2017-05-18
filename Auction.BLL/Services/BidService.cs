using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.BLL.DTOs;
using Auction.BLL.Exceptions;
using Auction.BLL.Intefraces;
using Auction.DAL.Entities;
using Auction.DAL.Interfaces;
using AutoMapper;

namespace Auction.BLL.Services
{
    
    public class BidService:IBidService
    {
        public IAuctionUnitOfWork Database { get; private set; }

        public BidService(IAuctionUnitOfWork database)
        {
            if (database == null)
                throw new ArgumentNullException("database");
            Database = database;
        }

        public IEnumerable<BidDTO> GetAllUserBids(string userId)
        {
            if (userId == null)
                throw new ArgumentNullException("userId");
            IEnumerable<Bid> bids = Database.Bids.GetAll().Where(b => b.Owner.Id == userId);
            if (bids == null)
                throw new ItemNotExistInDbException("user do not have any bids", userId);
            return Mapper.Map<IEnumerable<BidDTO>>(bids);
        }

        public int GetUserBidsCount(string userId)
        {
            if (userId == null)
                throw new ArgumentNullException("userId");
           int bidsCount = Database.Bids.GetAll().Count(b => b.Owner.Id == userId);
            
            return bidsCount;
        }

        public BidDTO Get(int? bidId)
        {
            if (bidId == null)
                throw new ArgumentNullException("bidId");
            Bid bid = Database.Bids.Get(bidId.Value);
            return Mapper.Map<BidDTO>(bid);
        }

        public void Create(BidDTO bid, string userId)
        {
            if (bid == null)
                throw new ArgumentNullException("bid");
            if (userId == null)
                throw new ArgumentNullException("userId");

            //Database.Bids.Create(Mapper.Map<Lot>(bid), );
            Database.Save();
        }

        public void Remove(int? bidId, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
