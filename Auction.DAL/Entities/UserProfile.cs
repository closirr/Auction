using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Entities
{
    public class UserProfile
    {
        [Key]
        [ForeignKey("Owner")]
        public string Id { get; set; }

        public DateTime RegistrationDate { get; set; }
        public ShippingData ShippingData { get; set; }

        public virtual User Owner { get; set; }
        public virtual List<Lot> Lots { get; set; }
        public virtual List<Bid> Bids { get; set; }

        public UserProfile()
        {
            Lots = new List<Lot>();
            Bids = new List<Bid>();
        }
    }
}
