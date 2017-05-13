using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.DAL.Contexts;
using Auction.DAL.Entities;
using Auction.DAL.Interfaces;

namespace Auction.DAL.Repositories
{
    public class UserProfileRepository:IUserProfileManager
    {
        private AuctionContext db;
        public UserProfileRepository(AuctionContext _db)
        {
            db = _db;
        }
        public IQueryable<UserProfile> GetAll()
        {

            return db.UserProfiles;
        }

        public UserProfile Get(int id)
        {
            return db.UserProfiles.Find(id);
        }

        public void Create(UserProfile item)
        {
            db.UserProfiles.Add(item);
        }

        public void Update(UserProfile item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            UserProfile item = db.UserProfiles.Find(id);
            if (item != null)
                db.UserProfiles.Remove(item);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
