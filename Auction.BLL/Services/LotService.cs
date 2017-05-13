using System;
using System.Collections.Generic;
using System.Linq;
using Auction.BLL.DTOs;
using Auction.BLL.Exceptions;
using Auction.BLL.Infrastructure;
using Auction.BLL.Intefraces;
using Auction.DAL.Entities;
using Auction.DAL.Interfaces;
using AutoMapper;

namespace Auction.BLL.Services
{
    class LotService:ILotService
    {
        public IAuctionUnitOfWork Database { get; private set; }

        public LotService(IAuctionUnitOfWork database)
        {
            if (database == null)
                throw new ArgumentNullException("database");
            Database = database;
        }
        public void Create(LotDTO lot)
        {
            if (lot == null)
                throw new ArgumentNullException("lot");
            Database.Lots.Create(Mapper.Map<Lot>(lot));
            Database.Save();
        }

        public void Remove(int? lotId)
        {
            if(lotId == null)
                throw new ArgumentNullException("lotId");
            Database.Lots.Delete(lotId.Value);
        }

        public void MakeABid(int? lotId, BidDTO bid)
        {
            if (bid == null)
                throw new ArgumentNullException("bid");
            if (lotId == null)
                throw new ArgumentNullException("lotId");


            Lot lot = Database.Lots.Get(lotId.Value);
            if (lot == null)
                throw new ItemNotExistInDbException("lot", lotId.Value);
            if (lot.Status != Status.Active)
                throw new InaccessibleLotException("inactive lot", lot.Id);

            lot.Bids.Add(Mapper.Map<Bid>(bid));
        }

        public LotDTO Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException("id");
            Lot lot = null;
            lot = Database.Lots.Get(id.Value);
            if (lot == null)
                throw new ItemNotExistInDbException("lot", id.Value);
            return Mapper.Map<LotDTO>(lot);
        }

        public void RemoveBid(int? lotId, int? bidId)
        {
            if (lotId == null)
                throw new ArgumentNullException("lotId");
            if (bidId == null)
                throw new ArgumentNullException("bidId");

            Lot lot = Database.Lots.Get(lotId.Value);
            if (lot == null)
                throw new ItemNotExistInDbException("lot", lotId.Value);
            Bid bid = lot.Bids.Find(b => b.Id == bidId);
            if (bid == null)
                throw new ItemNotExistInDbException("bid", bidId.Value);
            lot.Bids.Remove(bid);
        }

        public IEnumerable<LotDTO> GetAllInCategory(int? categoryId) //TODO Test SQL query performance
        {
            if (categoryId == null)
                throw new ArgumentNullException("id");
            IEnumerable<Lot> lots = Database.Lots.GetAll().
                Where(l => l.Category.Id == categoryId);
            
            return Mapper.Map<IEnumerable<LotDTO>>(lots);
        }

        public IEnumerable<LotDTO> GetAll()
        {
            IEnumerable<Lot> lots = Database.Lots.GetAll();
            return Mapper.Map<IEnumerable<LotDTO>>(lots);
        }

        public IEnumerable<LotDTO> GetFirstEarliest(int count)
        {
            IEnumerable<Lot> lots = Database.Lots.GetAll().OrderBy(l => l.CreateDate).Take(count);
            return Mapper.Map<IEnumerable<LotDTO>>(lots);
        }
    }
}
