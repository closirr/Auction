using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.BLL.Exceptions
{
    public class InaccessibleLotException:Exception
    {
        public string LotId { get; private set; }

        public InaccessibleLotException(string message, string _lotId):base(message)
        {
            LotId = _lotId;
        }
}
}
