using AutoMapper;
using NUShop.Data.Entities;
using NUShop.Data.Enums;
using NUShop.Data.IRepositories;
using NUShop.Infrastructure.Interfaces;
using NUShop.Service.Interfaces;
using NUShop.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NUShop.Service.Implements
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public CategoryViewModel Add(CategoryViewModel categoryViewModel)
        {
            var category = _mapper.Map<Category>(categoryViewModel);
            _categoryRepository.Add(category);
            _unitOfWork.CommitAsync();
            return categoryViewModel;
        }

        public void Delete(int id)
        {
            _categoryRepository.Remove(id);
            _unitOfWork.CommitAsync();
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

        public void ReOrder(int sourceId, int targetId)
        {
            throw new NotImplementedException();
        }

        public void Update(CategoryViewModel categoryViewModel)
        {
            var category = _mapper.Map<Category>(categoryViewModel);
            _categoryRepository.Update(category);
            _unitOfWork.CommitAsync();
        }

        public void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items)
        {
            throw new NotImplementedException();
        }
    }
}