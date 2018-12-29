using NUShop.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUShop.Service.Interfaces
{
    public interface ICategoryService
    {
        CategoryViewModel Add(CategoryViewModel categoryViewModel);

        void Update(CategoryViewModel categoryViewModel);

        void Delete(int id);

        IEnumerable<CategoryViewModel> GetAll();

        IEnumerable<CategoryViewModel> GetAll(string keyword);

        IEnumerable<CategoryViewModel> GetAllByParentId(int parentId);

        CategoryViewModel GetById(int id);

        void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items);
        void ReOrder(int sourceId, int targetId);

        IEnumerable<CategoryViewModel> GetHomeCategories(int top);
    }
}
