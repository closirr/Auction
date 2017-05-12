using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.BLL.DTOs;

namespace Auction.BLL.Intefraces
{
    interface ILotService
    {
        void Create(LotDTO lot);
        void Remove(int? lotId);
        void MakeABid(LotDTO lot, BidDTO bid);
        LotDTO Get(int? id);
        void RemoveBid(int? bidId);
        IEnumerable<LotDTO> GetAllInCategory(int? categoryId);
        IEnumerable<LotDTO> GetAll(int? categoryId);

    }
}
