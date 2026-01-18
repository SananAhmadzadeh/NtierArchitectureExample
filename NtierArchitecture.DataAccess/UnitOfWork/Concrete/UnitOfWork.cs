
using NtierArchitecture.DataAccess.Repositories.Concrete.EFCore;
using NtierArchitecture.DataAccess.UnitOfWork.Abstract;

namespace NtierArchitecture.DataAccess.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ExampleDbContext _context;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        public UnitOfWork(ExampleDbContext context)
        {
            _context = context;
        }
        public ICategoryRepository CategoryRepository => _categoryRepository ?? new EfCategoryRepository(_context);

        public IProductRepository ProductRepository => _productRepository ?? new EfProductRepository(_context);

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
