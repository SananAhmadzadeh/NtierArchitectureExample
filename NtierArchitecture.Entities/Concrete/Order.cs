

using Core.Entities.Abstract;
using NtierArchitecture.Entities.Common;

namespace NtierArchitecture.Entities.Concrete
{
    public class Order : BaseEntity, IEntity
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
