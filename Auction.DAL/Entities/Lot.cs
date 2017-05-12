using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Entities
{
    public class Lot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime CompletionDate { get; set; }

        public List<Bid> Bids { get; set; }
    }

}


