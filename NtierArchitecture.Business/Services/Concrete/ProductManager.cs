using AutoMapper;
using Core.Utilities.Exceptions;
using NtierArchitecture.Business.Services.Abstract;
using NtierArchitecture.Business.Utilities.Constants;
using NtierArchitecture.DataAccess.Repositories.Abstract;
using NtierArchitecture.DataAccess.UnitOfWork.Abstract;
using NtierArchitecture.Entities.Concrete;
using NtierArchitecture.Entities.DTOs.ProductDTOs;
using WebApiAdvanceExample.Entities.DTOs.ProductDTOs;

namespace NtierArchitecture.Business.Services.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;
        public ProductManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task AddProductAsync(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);

            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var result = await _unitOfWork.ProductRepository.GetAsync(p => p.Id == id);
            if (result is null)
            {
                throw new NotFoundException(ExceptionMessage.ProductNotFound);
            }
            await _unitOfWork.ProductRepository.DeleteAsync(result);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<GetAllProductsDto>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.ProductRepository.GetAllAsync();
            return _mapper.Map<List<GetAllProductsDto>>(products);
        }

        public async Task<GetProductDto> GetProductByIdAsync(Guid id)
        {
            var product = await _unitOfWork.ProductRepository.GetAsync(p=> p.Id == id);

            if(product is null)
            {
                throw new NotFoundException(ExceptionMessage.ProductNotFound);
            }

            return _mapper.Map<GetProductDto>(product);
        }
    }
}
