using Core.Entities.Abstract;
using NtierArchitecture.Entities.Common;

namespace NtierArchitecture.Entities.Concrete
{
    public class OrderItem : BaseEntity, IEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public string Description { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
