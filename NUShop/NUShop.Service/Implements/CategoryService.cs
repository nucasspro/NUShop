using AutoMapper;
using NUShop.Data.Entities;
using NUShop.Data.Enums;
using NUShop.Data.IRepositories;
using NUShop.Infrastructure.Interfaces;
using NUShop.Service.Interfaces;
using NUShop.Service.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NUShop.Service.Implements
{
    public class CategoryService : ICategoryService
    {
        #region Variables

        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        #endregion Variables

        #region Constructor

        public CategoryService(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        #endregion Constructor

        #region Implements

        public async Task<CategoryViewModel> Add(CategoryViewModel categoryViewModel)
        {
            var category = _mapper.Map<Category>(categoryViewModel);
            _categoryRepository.Add(category);
            await _unitOfWork.CommitAsync();
            return categoryViewModel;
        }

        public async Task Delete(int id)
        {
            _categoryRepository.Remove(id);
            await _unitOfWork.CommitAsync();
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            var categories = _categoryRepository.GetAll().OrderBy(x => x.Id);
            var categoriesViewModel = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
            return categoriesViewModel;
        }

        public IEnumerable<CategoryViewModel> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                var categories = _categoryRepository.GetAll(x => x.Name.Contains(keyword) || x.Description.Contains(keyword)).OrderBy(x => x.ParentId);
                var categoriesViewModel = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
                return categoriesViewModel;
            }
            else
            {
                var categories = _categoryRepository.GetAll().OrderBy(x => x.ParentId);
                var categoriesViewModel = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
                return categoriesViewModel;
            }
        }

        public IEnumerable<CategoryViewModel> GetAllByParentId(int parentId)
        {
            var categories = _categoryRepository.GetAll(x => x.ParentId == parentId && x.Status == Status.Active);
            var categoriesViewModel = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
            return categoriesViewModel;
        }

        public CategoryViewModel GetById(int id)
        {
            var category = _categoryRepository.GetById(id);
            var categoryViewModel = _mapper.Map<CategoryViewModel>(category);
            return categoryViewModel;
        }

        public IEnumerable<CategoryViewModel> GetHomeCategories(int top)
        {
            var categories = _categoryRepository.GetAll(x => x.HomeFlag == true, y => y.Products).OrderBy(x => x.HomeOrder).Take(top);
            var categoriesViewModel = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
            return categoriesViewModel;
        }

        public async Task ReOrder(int sourceId, int targetId)
        {
            var source = _categoryRepository.GetById(sourceId);
            var target = _categoryRepository.GetById(targetId);
            int tempOrder = source.SortOrder;
            source.SortOrder = target.SortOrder;
            target.SortOrder = tempOrder;

            _categoryRepository.Update(source);
            _categoryRepository.Update(target);
            await _unitOfWork.CommitAsync();
        }

        public async Task<CategoryViewModel> Update(CategoryViewModel categoryViewModel)
        {
            var category = _mapper.Map<Category>(categoryViewModel);
            _categoryRepository.Update(category);
            await _unitOfWork.CommitAsync();
            return categoryViewModel;
        }

        public async Task UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items)
        {
            var sourceCategory = _categoryRepository.GetById(sourceId);
            sourceCategory.ParentId = targetId;
            _categoryRepository.Update(sourceCategory);

            //Get all sibling
            var sibling = _categoryRepository.GetAll(x => items.ContainsKey(x.Id));
            foreach (var child in sibling)
            {
                child.SortOrder = items[child.Id];
                _categoryRepository.Update(child);
            }
            await _unitOfWork.CommitAsync();
        }

       

        #endregion Implements
    }
}