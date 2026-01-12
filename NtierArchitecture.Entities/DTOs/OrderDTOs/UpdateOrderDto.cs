using Core.Entities.Abstract;

namespace WebApiAdvanceExample.Entities.DTOs.OrderDTOs
{
    public record UpdateOrderDto(DateTime orderDate, decimal totalAmount) : IDto;
}
