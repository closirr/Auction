using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.BLL.DTOs;
using Auction.BLL.Exceptions;
using Auction.BLL.Intefraces;
using Auction.DAL.Entities;
using Auction.DAL.Interfaces;
using AutoMapper;

namespace Auction.BLL.Services
{
    class CategoryService:ICategoryService
    {
        public IAuctionUnitOfWork Database { get; private set; }

        public CategoryService(IAuctionUnitOfWork database)
        {
            if (database == null)
                throw new ArgumentNullException("database");
            Database = database;
        }
        public IEnumerable<CategoryDTO> GetAll()
        {
            IEnumerable<Category> lots = Database.Categories.GetAll();
            return Mapper.Map<IEnumerable<CategoryDTO>>(lots);
        }

        public CategoryDTO Get(int? categoryId)
        {
            if (categoryId == null)
                throw new ArgumentNullException("categoryId");
            Category category = Database.Categories.Get(categoryId.Value);
            if(category == null)
                throw new ItemNotExistInDbException("category", categoryId.Value);
            return Mapper.Map<CategoryDTO>(category);
        }

        public void Create(Category category)
        {
            if (category == null)
                throw new ArgumentNullException("category");
            Database.Categories.Create(Mapper.Map<Category>(category));
            Database.Save();
        }

        public void Remove(int? categoryId)
        {
            if (categoryId == null)
                throw new ArgumentNullException("categoryId");
            Database.Lots.Delete(categoryId.Value);
        }
    }
}
