using NUShop.Data.Entities;
using NUShop.Infrastructure.Interfaces;

namespace NUShop.Data.IRepositories
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
    }
}