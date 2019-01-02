using NUShop.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NUShop.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryViewModel> Add(CategoryViewModel categoryViewModel);

        Task<CategoryViewModel> Update(CategoryViewModel categoryViewModel);

        Task Delete(int id);

        IEnumerable<CategoryViewModel> GetAll();

        IEnumerable<CategoryViewModel> GetAll(string keyword);

        IEnumerable<CategoryViewModel> GetAllByParentId(int parentId);

        CategoryViewModel GetById(int id);

        Task UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items);

        Task ReOrder(int sourceId, int targetId);

        IEnumerable<CategoryViewModel> GetHomeCategories(int top);
    }
}
