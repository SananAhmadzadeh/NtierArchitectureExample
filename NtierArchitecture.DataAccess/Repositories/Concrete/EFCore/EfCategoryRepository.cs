namespace NtierArchitecture.DataAccess.Repositories.Concrete.EFCore
{
    public class EfCategoryRepository : EfBaseRepository<Category, ExampleDbContext>, ICategoryRepository
    {
        public EfCategoryRepository(ExampleDbContext context) : base(context) { }
    }
}
