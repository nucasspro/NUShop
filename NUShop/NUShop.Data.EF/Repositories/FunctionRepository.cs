using NUShop.Data.Entities;
using NUShop.Data.IRepositories;

namespace NUShop.Data.EF.Repositories
{
    public class FunctionRepository : Repository<Function, string>, IFunctionRepository
    {
        public FunctionRepository(AppDbContext context) : base(context)
        {
        }
    }
}