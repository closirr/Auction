using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.BLL.DTOs;
using Auction.DAL.Entities;

namespace Auction.BLL.Intefraces
{
    public interface IBidService
    {
        IEnumerable<BidDTO> GetAllUserBids(string userId);
        int GetUserBidsCount(string userId);
        BidDTO Get(string bidId);
        void Create(BidDTO bid, string userId);
        void Remove(string bidId, string userId);
    }
}
