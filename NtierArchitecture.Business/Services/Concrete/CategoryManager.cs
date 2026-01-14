using AutoMapper;
using Core.Utilities.Exceptions;
using NtierArchitecture.Business.Services.Abstract;
using NtierArchitecture.Business.Utilities.Constants;
using NtierArchitecture.DataAccess.UnitOfWork.Abstract;
using NtierArchitecture.Entities.Concrete;
using NtierArchitecture.Entities.DTOs.CategoryDTOs;
using WebApiAdvanceExample.Entities.DTOs.CategoryDTOs;

namespace NtierArchitecture.Business.Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task AddCategoryAsync(CreateCategoryDto dto)
        {
            var result = _mapper.Map<Category>(dto);
            await _unitOfWork.CategoryRepository.AddAsync(result);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteCategoryAsync(Guid id)
        {
            var deletedCategory = await _unitOfWork.CategoryRepository.GetAsync(c => c.Id == id);
            if(deletedCategory is null)
            {
                throw new NotFoundException(ExceptionMessage.CategoryNotFound);
            }
            await _unitOfWork.CategoryRepository.DeleteAsync(deletedCategory);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<GetAllCategoriesDto>> GetAllCategoriesAsync()
        {
            var categories = await _unitOfWork.CategoryRepository.GetAllAsync();
            var result = _mapper.Map<List<GetAllCategoriesDto>>(categories);
            return result;
        }

        public async Task<GetCategoryDto> GetCategoryByIdAsync(Guid id)
        {
            var category = await _unitOfWork.CategoryRepository.GetAsync(c => c.Id == id);
            if(category is null)
            {
                throw new NotFoundException(ExceptionMessage.CategoryNotFound);
            }
            var result = _mapper.Map<GetCategoryDto>(category);
            return result;
        }
    }
}
