

namespace NtierArchitecture.DataAccess.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; }
        public IProductRepository ProductRepository { get; }
        public Task<int> SaveAsync();
    }
}
