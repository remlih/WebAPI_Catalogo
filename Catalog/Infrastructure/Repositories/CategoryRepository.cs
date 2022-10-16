using Application.Interfaces.Repositories;
using Catalog.Application.Interfaces.Repositories;
using Catalog.Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IRepositoryAsync<Product, int> _repository;

        public CategoryRepository(IRepositoryAsync<Product, int> repository)
        {
            _repository = repository;
        }

        public async Task<bool> IsCategoryUsed(int categoryId)
        {
            return await _repository.Entities.AnyAsync(b => b.CategoryId == categoryId);
        }
    }
}
