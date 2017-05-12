using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Entities
{
    public class ShippingData
    {
        public int Id { get; set; }
        public string lastName { get; set; }
        public string FirstName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }

        public int? UserId { get; set; }
        public User Owner { get; set; }

    }
}
