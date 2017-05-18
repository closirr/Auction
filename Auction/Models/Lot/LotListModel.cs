using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Auction.Models
{
    public class LotListModel
    {
        public string Id { get; set; }
        public string OwnerId { get; set; }
        public string CurrentBidId { get; set; }
        public int BidCount { get; set; }
        public DateTime CompletionDate { get; set; }
        public string Name { get; set; }

         
  //      public TYPE Type { get; set; }

    }
}