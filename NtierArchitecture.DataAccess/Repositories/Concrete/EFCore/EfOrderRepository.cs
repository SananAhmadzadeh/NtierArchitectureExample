namespace NtierArchitecture.DataAccess.Repositories.Concrete.EFCore
{
    public class EfOrderRepository : EfBaseRepository<Order, ExampleDbContext>, IOrderRepository
    {
        public EfOrderRepository(ExampleDbContext context) : base(context) { }
    }
}
