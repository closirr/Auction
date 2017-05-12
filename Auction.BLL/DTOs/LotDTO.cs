﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.BLL.DTOs
{
    public class LotDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public string MainPicturePath { get; set; }
        public List<String> AdditionalPicturesPaths { get; set; }
        public StatusDTO Status { get; set; }
        public  CategoryDTO Category { get; set; }
        public  List<BidDTO> Bids { get; set; }

        public LotDTO()
        {
            AdditionalPicturesPaths = new List<string>();
            Bids = new List<BidDTO>();
        }

        public enum StatusDTO
        {
            Active,
            Ended,
            Banned
        }
    }
}
