using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.BLL.DTOs;
using Auction.DAL.Entities;
using AutoMapper;

namespace Auction.BLL.Infrastructure
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<Bid, BidDTO>();
            CreateMap<Category , CategoryDTO>();
            CreateMap<ShippingData, ShippingDataDTO>();
            CreateMap<Lot, LotDTO>();
        }
    }
}
