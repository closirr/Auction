﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Auction.DAL.Entities
{
    public class Bid
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal Price { get; set; }
        

        public int? LotId { get; set; }
        public Lot Lot { get; set; }

    }
}
