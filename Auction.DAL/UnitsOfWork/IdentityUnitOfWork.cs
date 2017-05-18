using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.DAL.Contexts;
using Auction.DAL.Entities;
using Auction.DAL.Identity;
using Auction.DAL.Interfaces;
using Auction.DAL.Repositories;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Auction.DAL.UnitsOfWork
{
    public class IdentityUnitOfWork:IIdentityUnitOfWork
    {
        private AuctionContext database;
        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;

        public IdentityUnitOfWork(string connectionString)
        {
            database = new AuctionContext(connectionString);
            userManager = new ApplicationUserManager(new UserStore<User>(database));
            roleManager = new ApplicationRoleManager(new RoleStore<Role>(database));
        }

        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return roleManager; }
        }

        public async Task SaveAsync()
        {
            try
            {

                await database.SaveChangesAsync();
            }
            catch (DbEntityValidationException ex)
            {
                throw new Exception(ex.Message + ex.EntityValidationErrors);
            }
        }
        public void Dispose()
        {
            database.Dispose();
        }

    }
}
