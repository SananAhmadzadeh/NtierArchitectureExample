using AutoMapper;
using Core.Entities.Concrete.Auth;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NtierArchitecture.Business.Services.Abstract;
using NtierArchitecture.Entities.DTOs.AutDTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiAdvanceExample.Entities.Auth;
using WebApiAdvanceExample.Entities.DTOs.AutDTOs;

namespace NtierArchitecture.Business.Services.Concrete.Auth
{
    public class AuthManager : IAuthService
    {
        private readonly UserManager<AppUser<Guid>> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly TokenOption? _tokenOption;
        public AuthManager(UserManager<AppUser<Guid>> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IConfiguration config)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _config = config;
            _tokenOption = _config.GetSection("TokenOptions").Get<TokenOption>();
        }

        public async Task<IResult> RegisterUserAsync(RegisterDto register)
        {
            var user = _mapper.Map<AppUser<Guid>>(register);

            var resultUser = await _userManager.CreateAsync(user, register.Password);

            if (!resultUser.Succeeded)
            {
                return new ErrorResult("Can not created this account!!!");
            }

            if (!await _roleManager.RoleExistsAsync("User"))
            {
                await _roleManager.CreateAsync(new IdentityRole("User"));
            }

            var resultRole = await _userManager.AddToRoleAsync(user, "User");

            if (!resultRole.Succeeded)
            {
                return new ErrorResult(@"The role ""User"" can not added this user");
            }

            return new SuccessResult("Account be created");
        }

        public async Task<IDataResult<LoginResponseDto>> LoginAsync(LoginDto login)
        {
            AppUser<Guid>? user = await _userManager.FindByNameAsync(login.UserName);
            if (user is null)
                return new ErrorDataResult<LoginResponseDto>("This user is not found");

            bool isValidPassword = await _userManager.CheckPasswordAsync(user, login.Password);
            if (!isValidPassword)
                return new ErrorDataResult<LoginResponseDto>("Password wrong");

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOption.SecurityKey));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                                new Claim(ClaimTypes.Name, user.UserName),
                                new Claim(ClaimTypes.Email, user.Email),
                            };

            var userRoles = await _userManager.GetRolesAsync(user);
            claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _tokenOption.Issuer,
                audience: _tokenOption.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_tokenOption.AccessTokenExpiration),
                signingCredentials: signingCredentials
            );

            string jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return new SuccessDataResult<LoginResponseDto>(new LoginResponseDto
            {
                Token = jwt,
                Expiration = token.ValidTo,
                UserName = user.UserName,
                Email = user.Email,
                Roles = userRoles
            }, 
            "Login success");

        }

        public async Task<IResult> AddAdminAsync(RegisterDto register)
        {
            var admin = _mapper.Map<AppUser<Guid>>(register);

            var resultAdmin = await _userManager.CreateAsync(admin, register.Password);

            if (!resultAdmin.Succeeded)
            {
                return new ErrorResult("Can not created this account!!!");
            }

            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            var resultRole = await _userManager.AddToRoleAsync(admin, "Admin");

            if (!resultRole.Succeeded)
            {
                return new ErrorResult(@"The role ""Admin"" can not added this admin");
            }

            return new SuccessResult("Account be created");

        }
    }
}
