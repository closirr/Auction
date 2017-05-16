using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.BLL.DTOs;
using Auction.Models;
using AutoMapper;

namespace Auction.Util
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //CreateMap<UserDTO, UserModel>();
            //CreateMap<BidDTO, BidModel>();
            //CreateMap<CategoryDTO, CategoryModel>();
            //CreateMap<ShippingDataDTO, ShippingDataModel>();
            CreateMap<LotDTO, LotListModel>()
                .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.Owner.Id))
                .ForMember(dest => dest.BidCount, opt => opt.MapFrom(src => src.Bids.Count))
                .ForMember(dest => dest.CurrentBidId,opt => opt.MapFrom(src => src.Bids.OrderBy(o => o.CreateDate).FirstOrDefault()));
        }
    }
}
