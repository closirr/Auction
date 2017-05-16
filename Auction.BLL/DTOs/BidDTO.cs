using System;

namespace Auction.BLL.DTOs
{
    public class BidDTO
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal Price { get; set; }

        public  LotDTO Lot { get; set; }
        public  UserDTO Owner { get; set; }

        public BidDTO()
        {
            CreateDate = DateTime.Now;

        }
    }
}
