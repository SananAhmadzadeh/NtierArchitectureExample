using AutoMapper;
using NtierArchitecture.Entities.Concrete;
using NtierArchitecture.Entities.DTOs.ProductDTOs;
using WebApiAdvanceExample.Entities.DTOs.ProductDTOs;

namespace NtierArchitecture.Business.Utilities.Profiles
{
    public class ProductProfiles : Profile
    {
        public ProductProfiles()
        {
            CreateMap<UpdateProductDto, Product>()
               .ForMember(desc => desc.UpdatedAt,
                          opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<CreateProductDto, Product>()
                .ForMember(desc => desc.CreatedAt,
                           opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(desc => desc.UpdatedAt,
                           opt => opt.MapFrom(_ => DateTime.UtcNow)).ReverseMap();

            CreateMap<Product, GetProductDto>();
            CreateMap<Product, GetAllProductsDto>();
        }
    }
}
