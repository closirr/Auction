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
    public class CategoryRepository : IRepository<Category,int>
    {
        private AuctionContext db;
        public CategoryRepository(AuctionContext _db)
        {
            db = _db;
        }
        public IQueryable<Category> GetAll()
        {

            return db.Categories;
        }

        public Category Get(int id)
        {
            return db.Categories.Find(id);
        }

        public void Create(Category item)
        {
            db.Categories.Add(item);
        }

        public void Update(Category item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Category item = db.Categories.Find(id);
            if (item != null)
                db.Categories.Remove(item);
        }
    }
}
