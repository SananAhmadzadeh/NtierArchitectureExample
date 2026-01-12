using Core.Entities.Abstract;

namespace Core.DataAccess.Services.Abstract
{
    public interface IBaseService<TIRepository, TEntityDto>
        where TIRepository : class, new()
        where TEntityDto : class, IDto, new()
    {
        public Task<List<TEntityDto>> GetAllAsync();
    }
}
