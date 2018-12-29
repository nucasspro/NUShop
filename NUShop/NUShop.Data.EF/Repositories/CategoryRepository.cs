using NUShop.Data.Entities;
using NUShop.Data.IRepositories;
using NUShop.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUShop.Data.EF.Repositories
{
    public class CategoryRepository : Repository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
