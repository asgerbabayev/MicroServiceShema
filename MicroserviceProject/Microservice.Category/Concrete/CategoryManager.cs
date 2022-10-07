using Microservice.Category.Abstract;
using Microservice.Category.Dtos;
using Microservice.Category.Repositories;
using M = Microservice.Domain.Entities;

namespace Microservice.Category.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository) =>
            _categoryRepository = categoryRepository;

        public async Task CreateAsync(CategoryWrite categoryWrite)
        {
            M.Category category = new M.Category()
            {
                CategoryName = categoryWrite.CategoryName
            };
            await _categoryRepository.CreateAsync(category);
        }

        public async Task<IEnumerable<CategoryRead>> GetAllAsync()
        {
            return await _categoryRepository.GetAllWithSelectAsync(x => x.Id, y => new CategoryRead
            {
                Id = y.Id,
                CategoryName = y.CategoryName
            });
        }
        public async Task<CategoryRead> GetAsync()
        {
            var result = await _categoryRepository.GetWithSelectAsync(x => x.Id, y => new CategoryRead
            {
                Id = y.Id,
                CategoryName = y.CategoryName
            });
            if (result is null) throw new Exception(); //TODO: Category null exception
            return result;
        }

        public async Task RemoveAsync(int id)
        {
            var result = await _categoryRepository.GetAsync(id);
            if (result is null) throw new Exception(); //TODO: Category null exception
            await _categoryRepository.RemoveAsync(result);
        }
    }
}
