namespace NtierArchitecture.DataAccess.Repositories.Concrete.EFCore
{
    public class EfOrderItemRepository : EfBaseRepository<OrderItem, ExampleDbContext>, IOrderItemRepository
    {
        public EfOrderItemRepository(ExampleDbContext context) : base(context) { }
    }
}
