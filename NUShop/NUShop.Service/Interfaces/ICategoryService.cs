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

        List<CategoryViewModel> GetAll();

        List<CategoryViewModel> GetAll(string keyword);

        List<CategoryViewModel> GetAllByParentId(int parentId);

        CategoryViewModel GetById(int id);

        Task UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items);

        Task ReOrder(int sourceId, int targetId);

        List<CategoryViewModel> GetHomeCategories(int top);
    }
}
