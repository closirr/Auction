﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.BLL.DTOs;
using Auction.DAL.Entities;

namespace Auction.BLL.Intefraces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDTO> GetAll();
        CategoryDTO Get(int? categoryId);
        void Create(CategoryDTO category);
        void Remove(int? categoryId);
    }
}
