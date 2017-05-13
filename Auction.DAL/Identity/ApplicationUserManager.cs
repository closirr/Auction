﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.DAL.Entities;
using Microsoft.AspNet.Identity;

namespace Auction.DAL.Identity
{
    public class ApplicationUserManager:UserManager<User>
    {
        public ApplicationUserManager(IUserStore<User> store) : base(store)
        {
        }
    }
}
