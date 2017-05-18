using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auction.Models.Account;

namespace Auction.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index(LoginModel loginModel)
        {
            if (loginModel == null)
            {
                loginModel = new LoginModel();
            }
            return View( loginModel);
        }
     

        [Authorize(Roles = "admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            
            return View();
        }
        [Authorize(Roles = "admin")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}