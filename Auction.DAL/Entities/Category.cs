using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Lot> Lots { get; set; }

        public Category()
        {
            Lots = new List<Lot>();
        }

    }
}
