using AuthApi.Model;

namespace AuthApi.Services.Interface
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> role);
    }
}
