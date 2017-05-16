using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auction.BLL.DTOs;
using Auction.BLL.Intefraces;
using Auction.BLL.Services;
using Auction.Models;

namespace Auction.Controllers
{
    public class LotController:Controller
    {
        private ILotService lotService;

        public LotController(ILotService _lotService)
        {
            lotService = _lotService;
        }

        [HttpGet]
        public ActionResult AutocompleteSearch(string searchWord)
        {
            IEnumerable<LotDTO> lots = lotService.FindByName(searchWord);
            IEnumerable<string> lotNames = lots.Select(l => l.Name).Distinct();
            return Json(lotNames, JsonRequestBehavior.AllowGet);
        }
    }
}