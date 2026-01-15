using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NtierArchitecture.Business.Services.Abstract;
using WebApiAdvanceExample.Entities.DTOs.AutDTOs;

namespace ExampleWebAPI.Controllers.Auth
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AuthController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto register)
        {
            await _accountService.RegisterAsync(register);

            return Ok(new
            {
                Message = "User registered successfully",
                Code = StatusCodes.Status200OK
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var result = await _accountService.LoginAsync(login);
            return Ok(result);
        }
    }
}
