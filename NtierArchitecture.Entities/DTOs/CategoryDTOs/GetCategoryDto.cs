using Core.Entities.Abstract;
using NtierArchitecture.Entities.Enums;
using WebApiAdvanceExample.Entities.Enums;

namespace WebApiAdvanceExample.Entities.DTOs.CategoryDTOs
{
    public record GetCategoryDto(string Name, string Description, CategoryStatus Status) : IDto;
}
