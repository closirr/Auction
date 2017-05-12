using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.BLL.DTOs
{
    public class UserDTO
    {
        public DateTime RegistrationDate { get; set; }
        public ShippingDataDTO ShippingData { get; set; }

        public  List<LotDTO> Lots { get; set; }
        public  List<BidDTO> Bids { get; set; }
        public UserDTO()
        {
            Lots = new List<LotDTO>();
            Bids = new List<BidDTO>();
        }
    }
}
