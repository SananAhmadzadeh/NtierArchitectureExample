using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using WebApiAdvanceExample.Entities.Enums;

namespace WebApiAdvanceExample.Entities.DTOs.ProductDTOs
{
    public record CreateProductDto(
        Guid CategoryId,
        string Name,
        string? Description,
        decimal Price,
        decimal? DiscountPrice,
        ProductStatus? Status,
        IFormFile ImageUrl
    ) : IDto;
}

