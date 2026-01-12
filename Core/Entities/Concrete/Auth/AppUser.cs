using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Concrete.Auth
{
    public class AppUser<Guid> : IdentityUser
    {
        public string? FullName { get; set; }
    }
}
