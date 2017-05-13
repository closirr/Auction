using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.BLL.Exceptions
{
    class InaccessibleLotException:Exception
    {
        public int LotId { get; private set; }

        public InaccessibleLotException(string message, int _lotId):base(message)
        {
            LotId = _lotId;
        }
}
}
