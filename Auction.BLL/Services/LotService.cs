using System;
using System.Collections.Generic;
using Auction.BLL.DTOs;
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
                throw new ArgumentNullException("lot");

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

        public void MakeABid(LotDTO lot, BidDTO bid)
        {
            if (bid == null)
                throw new ArgumentNullException("bid");
            if (lot.sta != LotDTO.StatusDTO.Active)
                throw 
        }

        public LotDTO Get(int id)
        {
            return null;
        }

        public void RemoveBid(int bidId)
        {
        }

        public IEnumerable<LotDTO> GetAllInCategory(int? categoryId)
        {
            yield break;
        }

        public IEnumerable<LotDTO> GetAll(int? categoryId)
        {
            yield break;
        }
    }
}
