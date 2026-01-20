using AutoMapper;
using Core.Utilities.Exceptions;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
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

        public async Task<IResult> AddCategoryAsync(CreateCategoryDto dto)
        {
            var result = _mapper.Map<Category>(dto);
            await _unitOfWork.CategoryRepository.AddAsync(result);
            var saveResult = await _unitOfWork.SaveAsync();
            if (saveResult == 0)
            {
                return new ErrorResult("Category can't added!");
            }
            return new SuccessResult("Category added..");
        }

        public async Task<IResult> DeleteCategoryAsync(Guid id)
        {
            var deletedCategory = await _unitOfWork.CategoryRepository.GetAsync(c => c.Id == id);
            if (deletedCategory is null)
            {
                throw new NotFoundException(ExceptionMessage.CategoryNotFound);
            }

            await _unitOfWork.CategoryRepository.DeleteAsync(deletedCategory);

            var saveResult = await _unitOfWork.SaveAsync();

            if (saveResult == 0)
            {
                return new ErrorResult("Category can't deleted!");
            }
            return new SuccessResult("Category deleted..");
        }

        public async Task<IDataResult<List<GetAllCategoriesDto>>> GetAllCategoriesAsync()
        {
            var categories = await _unitOfWork.CategoryRepository.GetAllAsync();

            if (categories.Count() == 0)
            {
                return new ErrorDataResult<List<GetAllCategoriesDto>>(_mapper.Map<List<GetAllCategoriesDto>>(categories), "Categories not found");
            }

            return new SuccessDataResult<List<GetAllCategoriesDto>>(_mapper.Map<List<GetAllCategoriesDto>>(categories), "Categories listed");
        }

        public async Task<IDataResult<GetCategoryDto>> GetCategoryByIdAsync(Guid id)
        {
            var category = await _unitOfWork.CategoryRepository.GetAsync(c => c.Id == id);

            if (category is null)
            {
                return new ErrorDataResult<GetCategoryDto>(_mapper.Map<GetCategoryDto>(category), "Category not found");
            }

            return new SuccessDataResult<GetCategoryDto>(_mapper.Map<GetCategoryDto>(category), "Category listed");
        }
    }
}
