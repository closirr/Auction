using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auction.BLL.DTOs;

namespace Auction.Models.Lot
{
    public class LotCreateModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(6, ErrorMessage = "Need to be more than 5 symbols")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the price like this \"18.54\"")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(6, ErrorMessage = "Need to be more than 10 symbols, some write information about your lot")]
        public string Description { get; set; }

        [Required]
        public string TimeToComplete { get; set; }

        public List<SelectListItem> Datas { get; set; }

        public string MainPicturePath { get; set; }
        public List<String> AdditionalPicturesPaths { get; set; }

        public CategoryDTO Category { get; set; }

        public LotCreateModel()
        {
            AdditionalPicturesPaths = new List<string>();
            Datas = new List<SelectListItem>();
        }

        public enum StatusModel
        {
            Active,
            Ended,
            Banned
        }
    }
}