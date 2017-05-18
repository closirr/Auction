using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using Auction.BLL.DTOs;
using Auction.BLL.Intefraces;
using Auction.Models.Lot;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Auction.BLL.Exceptions;
using Auction.Filters;

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
               
                return Json(models, JsonRequestBehavior.AllowGet);
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
            LotCreateModel lotModel = new LotCreateModel() { Description = "asf", MainPicturePath = "asf", Name = "asf", Price = 12 };
            lotModel.Datas.AddRange( new List<SelectListItem> {
                new SelectListItem() {Text = "3 days", Value = "3"},
                new SelectListItem() {Text = "7 days", Value = "7"},
                new SelectListItem() {Text = "14 days", Value = "14"},
                new SelectListItem() {Text = "31 days", Value = "31"}
                }
                );
            return View(lotModel);
        }

        [HttpPost]
        [Authorize]
     //   [TimeExpiriedException]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LotCreateModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    LotDTO lot = Mapper.Map<LotDTO>(model);
                    lotService.Create(User.Identity.GetUserId(), Mapper.Map<LotDTO>(model));
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