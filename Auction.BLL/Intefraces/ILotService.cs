using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.BLL.DTOs;

namespace Auction.BLL.Intefraces
{
    public interface ILotService
    {
        void Create(string userId, LotDTO lot);
        void Remove(int? lotId);
        void MakeABid(int? lotId, BidDTO bid);
        LotDTO Get(int? id);
        void RemoveBid(int? lotId, int? bidId);
        IEnumerable<LotDTO> FindByName(string lotName);
        IEnumerable<LotDTO> GetAllInCategory(int? categoryId);
        IEnumerable<LotDTO> GetAll();
        IEnumerable<LotDTO> GetFirstEarliest(int count);
    }
}
