using Core.Entities.Abstract;

namespace WebApiAdvanceExample.Entities.DTOs.OrderItemDTOs
{
    public record UpdateOrderItemDto(Guid OrderId, string Description, Guid ProductId, int Quantity, decimal UnitPrice) : IDto;
}
