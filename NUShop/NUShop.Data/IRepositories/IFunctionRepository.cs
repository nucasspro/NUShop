using NUShop.Data.Entities;
using NUShop.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUShop.Data.IRepositories
{
    public interface IFunctionRepository : IRepository<Function, string>
    {
    }
}
