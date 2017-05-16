using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.DAL.Entities;

namespace Auction.BLL.DTOs
{
    class UserProfileDTO
    {
        public string Id { get; set; }

        public DateTime RegistrationDate { get; set; }
        public ShippingDataDTO ShippingData { get; set; }

        public virtual UserDTO Owner { get; set; }

        public UserProfileDTO()
        {
            RegistrationDate = DateTime.Now;
        }
    }
}
