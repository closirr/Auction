using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.BLL.DTOs;

namespace Auction.BLL
{
    public class BidDTO
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal Price { get; set; }

        public  LotDTO Lot { get; set; }
        public  UserDTO Owner { get; set; }
    }
}
