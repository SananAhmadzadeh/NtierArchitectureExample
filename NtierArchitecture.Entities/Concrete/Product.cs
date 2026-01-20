using Core.Entities.Abstract;
using NtierArchitecture.Entities.Common;
using System.Text.Json.Serialization;
using WebApiAdvanceExample.Entities.Enums;

namespace NtierArchitecture.Entities.Concrete;

public class Product : BaseEntity, IEntity
{
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public decimal? DiscountPrice { get; set; }
    public string Currency { get; set; } = "AZN";
    public ProductStatus Status { get; set; }
    public string? ImagePath { get; set; }
}
