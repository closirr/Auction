using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auction.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        public ActionResult DbError(string error)
        {
            return View(error);
        }

    }
}