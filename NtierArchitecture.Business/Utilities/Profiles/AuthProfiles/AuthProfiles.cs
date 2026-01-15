using AutoMapper;
using Core.Entities.Concrete.Auth;
using WebApiAdvanceExample.Entities.Auth;
using WebApiAdvanceExample.Entities.DTOs.AutDTOs;

namespace WebApiAdvanceExample.Profiles.AuthProfiles
{
    public class AuthProfiles : Profile
    {
        public AuthProfiles()
        {
            CreateMap<RegisterDto, AppUser<Guid>>();
        }
    }
}
