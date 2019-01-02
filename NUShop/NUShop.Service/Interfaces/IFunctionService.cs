using NUShop.Service.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NUShop.Service.Interfaces
{
    public interface IFunctionService
    {
        Task<FunctionViewModel> Add(FunctionViewModel functionViewModel);

        Task<FunctionViewModel> Update(FunctionViewModel functionViewModel);

        Task Delete(string id);

        Task<IEnumerable<FunctionViewModel>> GetAll(string filter);

        IEnumerable<FunctionViewModel> GetAllByParentId(string parentId);

        FunctionViewModel GetById(string id);

        Task UpdateParentId(string sourceId, string targetId, Dictionary<string, int> items);

        Task ReOrder(string sourceId, string targetId);
    }
}
