using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Auction.BLL.DTOs;

namespace Auction.Models.Lot
{
    public class LotCreateModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime CompletionDate { get; set; }

        public string MainPicturePath { get; set; }
        public List<String> AdditionalPicturesPaths { get; set; }

        public CategoryDTO Category { get; set; }

        public LotCreateModel()
        {
            AdditionalPicturesPaths = new List<string>();
        }

        public enum StatusModel
        {
            Active,
            Ended,
            Banned
        }
    }
}