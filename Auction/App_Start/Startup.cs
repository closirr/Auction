using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Auction.App_Start;
using Auction.BLL.Intefraces;
using Auction.BLL.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
[assembly: OwinStartupAttribute(typeof(Startup))]
namespace Auction.App_Start
{
    public class Startup
    {
        private IServiceCreator _serviceCreator;

        public Startup()
        {
            _serviceCreator = new ServiceCreator();
        }

        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IUserService>(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Home/Index"),
            });
        }

        private IUserService CreateUserService()
        {
            return _serviceCreator.CreateUserService("DefaultConnection");
        }
    }
}