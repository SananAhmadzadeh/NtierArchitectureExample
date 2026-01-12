using Core.Entities.Abstract;

namespace WebApiAdvanceExample.Entities.DTOs.OrderDTOs
{
    public record CreateOrderDto(DateTime orderDate, decimal totalAmount) : IDto;
}
