using AutoMapper;
using NtierArchitecture.Entities.Concrete;
using NtierArchitecture.Entities.DTOs.CategoryDTOs;
using WebApiAdvanceExample.Entities.DTOs.CategoryDTOs;

namespace NtierArchitecture.Business.Utilities.Profiles
{
    public class CategoryProfiles : Profile
    {
        public CategoryProfiles()
        {
            CreateMap<Category, GetCategoryDto>();

            CreateMap<Category, GetAllCategoriesDto>();

            CreateMap<CreateCategoryDto, Category>()
                    .ForMember(desc => desc.CreatedAt,
                           opt => opt.MapFrom(_ => DateTime.UtcNow))
                    .ForMember(desc => desc.UpdatedAt,
                           opt => opt.MapFrom(_ => DateTime.UtcNow)).ReverseMap();
        }
    }
}
