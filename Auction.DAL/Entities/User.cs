using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Auction.DAL.Entities
{
    public class User:IdentityUser
    {
        public DateTime RegistrationDate { get; set; }
        public ShippingData ShippingData { get; set; }

        public virtual List<Lot> Lots { get; set; }
        public virtual List<Bid> Bids { get; set; }

        public User()
        {
            Lots = new List<Lot>();
            Bids = new List<Bid>();
        }
    }
}
