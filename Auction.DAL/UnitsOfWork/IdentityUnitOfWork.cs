using System;
using System.Collections.Generic;
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
        private IUserProfileManager userProfile;

        public IdentityUnitOfWork(string connectionString)
        {
            database = new AuctionContext(connectionString);
            userManager = new ApplicationUserManager(new UserStore<User>(database));
            roleManager = new ApplicationRoleManager(new RoleStore<Role>(database));
            userProfile = new UserProfileRepository(database);
        }

        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return roleManager; }
        }

        public IUserProfileManager UserProfile
        {
            get { return userProfile; }
        }

        public async Task SaveAsync()
        {
            await database.SaveChangesAsync();
        }
        public void Dispose()
        {
            database.Dispose();
        }

    }
}
