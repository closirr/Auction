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
            CreateMap<Status, StatusDTO>();
            CreateMap<User, UserDTO>().PreserveReferences();
            CreateMap<Bid, BidDTO>().PreserveReferences();
            CreateMap<Category, CategoryDTO>();
            CreateMap<ShippingData, ShippingDataDTO>().PreserveReferences();
            CreateMap<Lot, LotDTO>().PreserveReferences();
            CreateMap<StatusDTO, Status>();
            CreateMap<UserDTO, User>();
            CreateMap<UserProfile, UserProfileDTO>();
            CreateMap<UserProfileDTO, UserProfile>();


            CreateMap<BidDTO, Bid>()
                .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => Mapper.Map<UserProfile>(src.Owner)))
                .ForMember(dest => dest.Lot, opt => opt.MapFrom(src => Mapper.Map<Lot>(src.Lot)));

            CreateMap<CategoryDTO, Category>()
                .ForMember(dest => dest.Lots, opt => opt.MapFrom(src => Mapper.Map<List<Bid>>(src.Lots)));

            CreateMap<LotDTO, Lot>()
                .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => Mapper.Map<UserProfile>(src.Owner)))
                .ForMember(dest => dest.Bids, opt => opt.MapFrom(src => Mapper.Map <IEnumerable<Bid>>(src.Bids)))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => Mapper.Map<Category>(src.Category)))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Mapper.Map<Status>(src.Status)));
        }
    }
}
