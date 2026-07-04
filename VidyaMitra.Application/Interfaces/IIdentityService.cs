namespace VidyaMitra.Application.Interfaces;

public interface IIdentityService
{
    string GenerateToken(string userId, string email, string role);
}
