﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Auction.BLL.DTOs;
using Auction.BLL.Infrastructure;
using Auction.BLL.Intefraces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Auction.Models;
using Auction.Models.Account;

namespace Auction.Controllers
{
    public class AccountController : Controller
    {
        private IUserService UserService
        {
            get
            {
                
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginModel model)
        {
            await SetInitialDataAsync();

            if (ModelState.IsValid)
            {
                ClaimsIdentity claim = null;
                UserDTO userDto = new UserDTO {Email = model.Email, Password = model.Password};
                try
                {
                     claim = await UserService.Authenticate(userDto);
                }
                catch (Exception ex)
                {
                    return RedirectToAction("DbError", "Error", ex.Message);
                }
                if (claim == null)
                {
                    ModelState.AddModelError("", "Wrong login or password");
                    model.IsLoginDropDownOpened = true;
                    model.Password = "";
                    model.ErrorMessage = "Wrong login or password";
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home",model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult NotAutenticated()
        {
            LoginModel loginModel = new LoginModel();
            loginModel.IsLoginDropDownOpened = true;
            return RedirectToAction("Index", "Home", loginModel);
        }

        public ActionResult Register()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
           // await SetInitialDataAsync();

             if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO
                {
                    Email = model.Email,
                    Password = model.Password,
                    Name = model.Name,
                    Role = "user"
                };
                OperationDetails operationDetails = await UserService.Create(userDto);
                if (operationDetails.Succedeed)
                    return View("SuccessRegister");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }



        private async Task SetInitialDataAsync()
        {
            await UserService.SetInitialData(new UserDTO
            {
                Email = "somemail@mail.ru",
                UserName = "somemail@mail.ru",
                Password = "ad46D_ewr3",
                Name = "Admin",
                Role = "admin",
                
            }, new List<string> {"user", "admin"});
        }
    }
}