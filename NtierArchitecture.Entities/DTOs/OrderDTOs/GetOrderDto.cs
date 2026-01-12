using Core.Entities.Abstract;

namespace WebApiAdvanceExample.Entities.DTOs.OrderDTOs
{
    public record GetOrderDto(DateTime orderDate, decimal totalAmount) : IDto;

}
