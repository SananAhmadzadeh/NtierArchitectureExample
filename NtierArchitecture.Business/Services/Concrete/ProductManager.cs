using AutoMapper;
using NtierArchitecture.Business.Services.Abstract;
using NtierArchitecture.DataAccess.Repositories.Abstract;
using WebApiAdvanceExample.Entities.DTOs.ProductDTOs;

namespace NtierArchitecture.Business.Services.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductManager(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public Task<List<GetProductDto>> GetAllProductsAsync()
        {
            var products =  _repository.GetAllAsync();
            return _mapper.Map<Task<List<GetProductDto>>>(products);
        }
    }
}
