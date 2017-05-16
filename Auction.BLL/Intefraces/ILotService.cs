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
        void Create(LotDTO lot);
        void Remove(string lotId);
        void MakeABid(string lotId, BidDTO bid);
        LotDTO Get(string id);
        void RemoveBid(string lotId, string bidId);
        IEnumerable<LotDTO> FindByName(string lotName);
        IEnumerable<LotDTO> GetAllInCategory(int? categoryId);
        IEnumerable<LotDTO> GetAll();
        IEnumerable<LotDTO> GetFirstEarliest(int count);
    }
}
