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

            CreateMap<LotDTO, Lot>()
                .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => Mapper.Map<User>(src.Owner)))
                .ForMember(dest => dest.Bids, opt => opt.MapFrom(src => Mapper.Map <IEnumerable<Bid>>(src.Bids)))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => Mapper.Map<Category>(src.Category)));
            CreateMap<BidDTO, Bid>();
            CreateMap<CategoryDTO, Category>();

        }
    }
}
