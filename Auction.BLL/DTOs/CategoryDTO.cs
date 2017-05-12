using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.BLL.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  List<LotDTO> Lots { get; set; }

        public CategoryDTO()
        {
            Lots = new List<LotDTO>();
        }
    }
}
