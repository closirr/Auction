﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Auction.DAL.Entities
{
    public class User : IdentityUser
    {
        public virtual UserProfile UserProfile { get; set; }
    }
}
