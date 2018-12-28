using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NUShop.Infrastructure.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">T is class/entity</typeparam>
    /// <typeparam name="K">K is key</typeparam>
    public interface IRepository<T, K> where T : class
    {
        T FindById(K id, params Expression<Func<T, Object>>[] includeProperties);
    }
}
