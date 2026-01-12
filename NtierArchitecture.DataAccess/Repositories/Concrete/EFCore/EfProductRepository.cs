namespace NtierArchitecture.DataAccess.Repositories.Concrete.EFCore
{
    public class EfProductRepository : EfBaseRepository<Product, ExampleDbContext>, IProductRepository
    {
        public EfProductRepository(ExampleDbContext context) : base(context) { }
    }
}
