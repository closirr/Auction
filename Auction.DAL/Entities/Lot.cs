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
        public string MainPicturePath { get; set; }
        public List<String> AdditionalPicturesPaths { get; set; }
        public Status Status { get; set; }

        public virtual Category Category { get; set; }
        public virtual List<Bid> Bids { get; set; }

        public Lot()
        {
            Bids = new List<Bid>();
            AdditionalPicturesPaths = new List<string>();
            Status = Status.Active;
        }
    }
    public enum Status
    {
        Active,
        Ended,
        Banned
    }

}


