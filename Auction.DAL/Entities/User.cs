using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Entities
{
    public class User
    {
        public virtual List<Bid> Bids { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
