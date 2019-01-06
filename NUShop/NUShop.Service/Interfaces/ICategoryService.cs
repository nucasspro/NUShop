using NUShop.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NUShop.Service.Interfaces
{
    public interface ICategoryService
    {
        CategoryViewModel Add(CategoryViewModel categoryViewModel);

        void Update(CategoryViewModel categoryViewModel);

        void Delete(int id);

        List<CategoryViewModel> GetAll();

        List<CategoryViewModel> GetAll(string keyword);

        List<CategoryViewModel> GetAllByParentId(int parentId);

        CategoryViewModel GetById(int id);

        void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items);
        void ReOrder(int sourceId, int targetId);

        List<CategoryViewModel> GetHomeCategories(int top);
    }
}
