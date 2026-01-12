using Core.Entities.Abstract;
using NtierArchitecture.Entities.Common;
using NtierArchitecture.Entities.Enums;

namespace NtierArchitecture.Entities.Concrete;

public class Category: BaseEntity, IEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public CategoryStatus Status { get; set; }
    public List<Product> Products { get; set; }
}
