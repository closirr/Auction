using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Web.Mvc;
using Auction.BLL.DTOs;
using Auction.BLL.Intefraces;
using Auction.Models.Lot;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Auction.BLL.Exceptions;

namespace Auction.Controllers
{
    public class LotController:Controller
    {
        private ILotService lotService;


        public LotController(ILotService lotService)
        {
            this.lotService = lotService;
        }

        public ActionResult AutocompleteSearch(string term)
        {
            try
            {
                if (string.IsNullOrEmpty(term))
                {
                    return Json(new { value = "" }, JsonRequestBehavior.AllowGet);
                }
                IEnumerable<LotDTO> lots = lotService.FindByName(term);
                if (lots == null)
                {
                    return Json(new {value = "Can’t find anything"}, JsonRequestBehavior.AllowGet);
                }
                IEnumerable<string> lotNames = lots.Select(l => l.Name).Distinct();
                var models = lotNames.Where(a => a.Contains(term))
                    .Select(a => new {value = a})
                    .Distinct();
                IEnumerable<string> lotNamesTest = new List<string>() { "a", "b", "c", "d" }; //for test
                var models2 = lotNamesTest.Where(a => a.Contains(term))
                    .Select(a => new { value = a })
                    .Distinct();
                return Json(models2, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View(new LotCreateModel());
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LotCreateModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    LotDTO lot = Mapper.Map<LotDTO>(model);
                    lotService.Create(User.Identity.GetUserId(), Mapper.Map<LotDTO>(model));
                    ViewBag.Success = "Comment was successfully added";
                    ModelState.Clear();
                }
                catch (ItemNotExistInDbException)
                {
                    return new HttpStatusCodeResult(400, "Account was removed");
                }
            }
            return View(model);
        }
    }
}