using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NtierArchitecture.Business.Services.Abstract;
using WebApiAdvanceExample.Entities.DTOs.AutDTOs;

namespace ExampleWebAPI.Controllers.Auth
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _accountService;

        public AuthController(IAuthService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("User Register")]
        public async Task<IActionResult> RegisterUser(RegisterDto register)
        {
            var result = await _accountService.RegisterUserAsync(register);

            if(!result.Success)
                return BadRequest(result);

            return StatusCode(StatusCodes.Status201Created, result);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("Add Admin")]
        public async Task<IActionResult> AddAdmin(RegisterDto register)
        {
            var result = await _accountService.AddAdminAsync(register);

            if (!result.Success)
                return BadRequest(result);

            return StatusCode(StatusCodes.Status201Created, result);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var result = await _accountService.LoginAsync(login);
            if(!result.Success)
                return Unauthorized(result);

            return Ok(result);  
        }
    }
}
