using Core.Entities.Abstract;
using WebApiAdvanceExample.Entities.Enums;

namespace NtierArchitecture.Entities.DTOs.ProductDTOs
{
    public record GetAllProductsDto(
        Guid Id, 
        string Name, 
        string? Description, 
        decimal Price, 
        decimal? DiscountPrice, 
        ProductStatus? Status,
        string? ImagePath
        ) : IDto;
}
