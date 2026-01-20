using AutoMapper;
using Core.Utilities.Exceptions;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using NtierArchitecture.Business.Services.Abstract;
using NtierArchitecture.Business.Utilities.Constants;
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
        private readonly IFileService _fileService;
        public ProductManager(IMapper mapper, IUnitOfWork unitOfWork, IFileService fileService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public async Task<IResult> AddProductAsync(CreateProductDto dto)
        {
            string uploadedFilePath = await _fileService.UploadAsync(dto.ImageUrl, "products");

            var product = _mapper.Map<Product>(dto);

            product.ImagePath = uploadedFilePath;

            await _unitOfWork.ProductRepository.AddAsync(product);
            var saveResult = await _unitOfWork.SaveAsync();

            if (saveResult == 0)
            {
                _fileService.Delete(uploadedFilePath);
                return new ErrorResult("Product can't added!");
            }

            return new SuccessResult("Product added...");
        }

        public async Task<IResult> DeleteProductAsync(Guid id)
        {
            var result = await _unitOfWork.ProductRepository.GetAsync(p => p.Id == id);

            if (result is null)
            {
                throw new NotFoundException(ExceptionMessage.ProductNotFound);
            }

            _fileService.Delete(result.ImagePath);

            await _unitOfWork.ProductRepository.DeleteAsync(result);
            var saveResult = await _unitOfWork.SaveAsync();

            if (saveResult == 0)
            {
                return new ErrorResult("Product can't deleted!");
            }

            return new SuccessResult("Product deleted...");
        }

        public async Task<IDataResult<List<GetAllProductsDto>>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.ProductRepository.GetAllAsync();
            
            if(products.Count == 0)
            {
                return new ErrorDataResult<List<GetAllProductsDto>>(_mapper.Map<List<GetAllProductsDto>>(products), "Products can't listed!");
            }
            return new SuccessDataResult<List<GetAllProductsDto>>(_mapper.Map<List<GetAllProductsDto>>(products), "Products listed!");
        }

        public async Task<IDataResult<GetProductDto>> GetProductByIdAsync(Guid id)
        {
            var product = await _unitOfWork.ProductRepository.GetAsync(p => p.Id == id);

            if (product is null)
            {
                return new ErrorDataResult<GetProductDto>(_mapper.Map<GetProductDto>(product), "Product not found");
            }

            return new SuccessDataResult<GetProductDto>(_mapper.Map<GetProductDto>(product), "Product not found");
        }
    }
}
