using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Entities
{
    public class ShippingData
    {
        [Key]
        [ForeignKey("Owner")]
        public string Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
         
        public User Owner { get; set; } //TODO check if this will be deleted if owner deleted

    }
}
