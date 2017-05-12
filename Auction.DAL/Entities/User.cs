﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Entities
{
    public class User
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
