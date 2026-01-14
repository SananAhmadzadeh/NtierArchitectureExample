

using Core.Entities.Abstract;
using NtierArchitecture.Entities.Enums;

namespace NtierArchitecture.Entities.DTOs.CategoryDTOs
{
    public record GetAllCategoriesDto(Guid id, string Name, string Description, CategoryStatus Status) : IDto;
}
