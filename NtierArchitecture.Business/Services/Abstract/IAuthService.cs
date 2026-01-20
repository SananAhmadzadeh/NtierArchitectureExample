using Core.Utilities.Result.Abstract;
using NtierArchitecture.Entities.DTOs.AutDTOs;
using WebApiAdvanceExample.Entities.DTOs.AutDTOs;

namespace NtierArchitecture.Business.Services.Abstract
{
    public interface IAuthService
    {
        public Task<IResult> RegisterUserAsync(RegisterDto register);
        public Task<IDataResult<LoginResponseDto>> LoginAsync(LoginDto login);
        public Task<IResult> AddAdminAsync(RegisterDto register);
    }
}
