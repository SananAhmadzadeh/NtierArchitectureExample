using NtierArchitecture.Entities.DTOs.AutDTOs;
using WebApiAdvanceExample.Entities.DTOs.AutDTOs;

namespace NtierArchitecture.Business.Services.Abstract
{
    public interface IAccountService
    {
        public Task RegisterAsync(RegisterDto register);
        public Task<LoginResponseDto> LoginAsync(LoginDto login);
    }
}
