using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Auction.DAL.Entities
{
    public class Bid
    {
        [Key]
        [ForeignKey("Owner")]
        public string Id { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal Price { get; set; }
        

        public int LotId { get; set; }
        public virtual Lot Lot { get; set; }

        public virtual UserProfile Owner { get; set; }

        public Bid()
        {
            CreateDate = DateTime.Now;
        }

    }
}
