using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.BLL.Exceptions
{
    class ItemNotExistInDbException:Exception
    {
        public string ItemId { get; set; }
        public ItemNotExistInDbException(string message, string itemId) : base(message)
        {
            ItemId = itemId;
        }
    }
}
